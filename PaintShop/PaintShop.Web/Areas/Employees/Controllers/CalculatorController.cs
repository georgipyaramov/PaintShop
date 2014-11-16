namespace PaintShop.Web.Areas.Employees.Controllers
{
    using PaintShop.Data;
    using PaintShop.Web.Areas.Employees.Controllers.Base;
    using PaintShop.Web.Areas.Employees.ViewModels.Calculator;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using PaintShop.Models;

    public class CalculatorController : EmployeesController
    {
        public CalculatorController(IPaintShopData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var price = 0m;

            if (TempData["Price"] != null)
            {
                price = (decimal)this.TempData["Price"];
            }

            return View(price);
        }

        public ActionResult ReadProducts()
        {
            var products = this.Data.Products.All()
                               .Project()
                               .To<ProductWithPrIdViewModel>();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadColors()
        {
            var products = this.Data.Colors.All()
                               .Project()
                               .To<ColorViewModel>();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Calculate(CalculationParametersInputModel model)
        {
            var product = this.Data.Products.GetById(model.Product);
            var color = this.Data.Colors.GetById(model.Color);

            var priceTable = this.Data.ProductsColorsPackagesPrices.All()
                                 .Where(x => x.ProductId == product.Id &&
                                             x.ColorId == color.Id);

            var packs = priceTable.OrderByDescending(x => x.Package.Quantity)
                                  .Select(x => x.Package.Quantity)
                                  .ToList();

            var litterNeeded = this.CalculateLittersNeeded(model.Quadrature, product.Consumtion);
            var packsNeeded = this.CalculateNeededPackages(litterNeeded, packs);
            var price = this.CalculatePrice(packsNeeded, packs, priceTable);

            price += this.CalculatePriceOfAdjacentProducts(product, color, model);

            this.TempData["Price"] = price;

            return RedirectToAction("Index");
        }

        private IList<int> CalculateNeededPackages(int litersNeeded, List<int> packs)
        {
            var result = new int[packs.Count];

            for (int i = 0; i < packs.Count; i++)
            {
                result[i] = litersNeeded / packs[i];
                litersNeeded -= (result[i] * packs[i]);
            }

            return result.ToList();
        }

        private int CalculateLittersNeeded(double quadrature, double productConsumption)
        {
            return (int)(Math.Round(quadrature / productConsumption));
        }

        private decimal CalculatePrice(IList<int> neededPackages, IList<int> availablePackages, IQueryable<ProductColorPackagePrice> priceTable)
        {
            var price = 0m;

            for (int i = 0; i < neededPackages.Count; i++)
            {
                var currentNeededPack = neededPackages[i];
                var currentPack = availablePackages[i];
                price += priceTable.Where(x => x.Package.Quantity == currentPack).FirstOrDefault().Price * currentNeededPack;
            }

            return price;
        }

        private decimal CalculatePriceOfAdjacentProducts(Product product, Color color, CalculationParametersInputModel model)
        {
            var priceOfAdjacentProducts = 0m;

            foreach (var prod in product.AdjacentProducts)
            {
                var priceTable2 = this.Data.ProductsColorsPackagesPrices.All()
                                 .Where(x => x.ProductId == prod.Id &&
                                             x.ColorId == color.Id);
                if (priceTable2.Count() == 0)
                {
                    priceTable2 = this.Data.ProductsColorsPackagesPrices.All()
                                     .Where(x => x.ProductId == prod.Id);
                }

                var packs2 = priceTable2.OrderByDescending(x => x.Package.Quantity)
                                  .Select(x => x.Package.Quantity)
                                  .ToList();

                var litterNeeded2 = this.CalculateLittersNeeded(model.Quadrature, prod.Consumtion);
                var packsNeeded2 = this.CalculateNeededPackages(litterNeeded2, packs2);
                var price2 = this.CalculatePrice(packsNeeded2, packs2, priceTable2);

                priceOfAdjacentProducts += price2;
            }

            return priceOfAdjacentProducts;
        }
    }
}