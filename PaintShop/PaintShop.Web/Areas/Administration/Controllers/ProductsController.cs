namespace PaintShop.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using PaintShop.Data;
    using PaintShop.Models;
    using PaintShop.Web.Controllers;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PaintShop.Web.ViewModels;
    using PaintShop.Web.Areas.Administration.Controllers.Base;

    public class ProductsController : AdministrationController
    {
        public ProductsController(IPaintShopData data) : base(data)
        {
        }

        // GET: Administration/Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]
                                 DataSourceRequest request)
        {
            var allProducts = this.Data.Products.All()
                                  .Project()
                                  .To<SimpleProductViewModel>();

            var result = allProducts.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadCategories()
        {
            var categories = this.Data.Categories.All()
                                 .Project()
                                 .To<SimpleCategoryViewModel>();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadTypes(int? category)
        {
            var types = this.Data.Categories.GetById(category).Types
                            .AsQueryable()
                            .Project()
                            .To<SimpleProductTypeViewModel>();

            return Json(types, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadAdjacentProducts()
        {
            var products = this.Data.Products.All()
                               .Project()
                               .To<SimpleProductViewModel>();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create([DataSourceRequest]
                                   DataSourceRequest request, SimpleProductViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var productDbModel = Mapper.Map<Product>(model);
                this.Data.Products.Add(productDbModel);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Update([DataSourceRequest]
                                   DataSourceRequest request, SimpleProductViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var productDbModel = this.Data.Products.GetById(model.Id);

                Mapper.Map(model, productDbModel);
                this.UpdateAdjacentProducts(productDbModel, model);

                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Destroy([DataSourceRequest]
                                   DataSourceRequest request, SimpleProductViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Products.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private void UpdateAdjacentProducts(Product productDbModel, SimpleProductViewModel model)
        {
            var adjProds = new List<Product>();

            if (model.AdjacentProducts != null)
            {
                foreach (var item in model.AdjacentProducts)
                {
                    var prod = this.Data.Products.GetById(item.Id);
                    adjProds.Add(prod);
                }
            }

            productDbModel.AdjacentProducts = adjProds;
        }
    }
}