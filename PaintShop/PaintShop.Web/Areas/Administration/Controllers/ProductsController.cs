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
    using System.Collections;

    using Model = PaintShop.Models.Product;
    using ViewModel = PaintShop.Web.Areas.Administration.ViewModels.Products.ProductViewModel;

    public class ProductsController : KendoGridAdministrationController
    {
        public ProductsController(IPaintShopData data) : base(data)
        {
        }

        // GET: Administration/Products
        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Products.All()
                                  .Project()
                                  .To<ViewModel>();
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

        [HttpPost]
        public ActionResult Create([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        public ActionResult Update([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var productDbModel = this.Data.Products.GetById(model.Id);
                Mapper.Map(model, productDbModel);
                this.UpdateAdjacentProducts(productDbModel, model);
                this.UpdateCategory(productDbModel, model);
                this.UpdateProductType(productDbModel, model);

                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        public ActionResult Destroy([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Products.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Products.GetById(id) as T;
        }

        protected override void CreateCustomBindings(object dbModel, object model)
        {
            this.UpdateCategory((Model)dbModel, (ViewModel)model);
            this.UpdateProductType((Model)dbModel, (ViewModel)model);
            this.UpdateAdjacentProducts((Model)dbModel, (ViewModel)model);
        }

        private void UpdateAdjacentProducts(Model dbModel, ViewModel model)
        {
            var adjProds = new List<Product>();

            if (model.AdjacentProducts != null)
            {
                foreach (var item in model.AdjacentProducts)
                {
                    var allProducts = this.Data.Products.All().ToList(); 
                    var prod = this.Data.Products.All().Where(x => x.Id == item.Id).FirstOrDefault();
                    adjProds.Add(prod);
                }
            }

            dbModel.AdjacentProducts = adjProds;
        }

        private void UpdateCategory(Model dbModel, ViewModel model)
        {
            var category = this.Data.Categories.GetById(model.Category.Id);
            dbModel.Category = category;
        }

        private void UpdateProductType(Model dbModel, ViewModel model)
        {
            var productType = this.Data.Types
                .GetById(model.ProductType.Id);
            dbModel.ProductType = productType;
        }
    }
}