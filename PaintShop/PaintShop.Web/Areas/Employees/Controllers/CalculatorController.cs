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
            var calculatedProducts = new List<CalculatorProductResultViewModel>();

            if (TempData["Price"] != null)
            {
                price = (decimal)this.TempData["Price"];
            }

            if (this.TempData["CalculatedProducts"] != null)
            {
                calculatedProducts = (List<CalculatorProductResultViewModel>)this.TempData["CalculatedProducts"];
            }

            return View(calculatedProducts);
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
            var calculatedProducts = new List<CalculatorProductResultViewModel>();

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

            var calculatedProduct = new CalculatorProductResultViewModel()
            {
                Type = product.ProductType.Name,
                Name = product.Name,
                LitersNeeded = litterNeeded,
                TotalPrice = price,
                Identificator = product.ProductIdentificator,
                ColorIdentificator = color.ColorIdentificator
            };

            calculatedProducts.Add(calculatedProduct);

            price += this.CalculatePriceOfAdjacentProducts(product, color, model, calculatedProducts);

            this.TempData["CalculatedProducts"] = calculatedProducts;
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
            var lll = (int)(Math.Round(quadrature / productConsumption));
            if ((quadrature / productConsumption) - productConsumption > 0)
            {
                lll++;
            }
            return lll;
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

        private decimal CalculatePriceOfAdjacentProducts(Product product, Color color, CalculationParametersInputModel model, IList<CalculatorProductResultViewModel> calculatedProducts)
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

                var calculatedProduct = new CalculatorProductResultViewModel()
                {
                    Type = prod.ProductType.Name,
                    Name = prod.Name,
                    LitersNeeded = litterNeeded2,
                    TotalPrice = price2,
                    Identificator = prod.ProductIdentificator,
                    ColorIdentificator = priceTable2.FirstOrDefault().Color.ColorIdentificator
                };

                calculatedProducts.Add(calculatedProduct);

                priceOfAdjacentProducts += price2;

                priceOfAdjacentProducts += CalculatePriceOfAdjacentProducts(prod, color, model, calculatedProducts);

            }

            return priceOfAdjacentProducts;
        }
    }
}