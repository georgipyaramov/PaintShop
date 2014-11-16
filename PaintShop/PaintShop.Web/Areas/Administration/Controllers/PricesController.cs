namespace PaintShop.Web.Areas.Administration.Controllers
{
    using Kendo.Mvc.UI;
    using PaintShop.Data;
    using PaintShop.Web.Areas.Administration.Controllers.Base;
    using PaintShop.Web.Areas.Administration.ViewModels.Prices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using PaintShop.Web.ViewModels;
    using PaintShop.Web.Areas.Administration.ViewModels.Colors;
    using PaintShop.Web.Areas.Administration.ViewModels.Packages;

    using Model = PaintShop.Models.ProductColorPackagePrice;
    using ViewModel = PaintShop.Web.Areas.Administration.ViewModels.Prices.PricesViewModel;
    using AutoMapper;

    public class PricesController : KendoGridAdministrationController
    {
        public PricesController(IPaintShopData data)
            : base(data)
        {
        }

        // GET: Administration/Prices
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadColors()
        {
            var colors = this.Data.Colors.All()
                                 .Project()
                                 .To<ColorViewModel>();

            return Json(colors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadProducts()
        {
            var products = this.Data.Products.All()
                                 .Project()
                                 .To<BasicProductViewModel>();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadPackages()
        {
            var products = this.Data.Packages.All()
                                 .Project()
                                 .To<PackageViewModel>();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            return this.GridOperation(model, request);
        }

        public ActionResult Update([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);

            return this.GridOperation(model, request);
        }

        public ActionResult Destroy([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.ProductsColorsPackagesPrices.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override System.Collections.IEnumerable GetData()
        {
            return this.Data.ProductsColorsPackagesPrices.All()
                       .Project()
                       .To<PricesViewModel>();       
        }

        protected override void CreateCustomBindings(object dbModel, object model)
        {
            this.AsignProduct((Model)dbModel, (ViewModel)model);
            this.AsignColor((Model)dbModel, (ViewModel)model);
            this.AsignPackage((Model)dbModel, (ViewModel)model);
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.ProductsColorsPackagesPrices.GetById(id) as T;
        }

        private void AsignProduct(Model dbModel, ViewModel model)
        {
            var product = this.Data.Products.GetById(model.Product.Id);
            dbModel.Product = product;
        }

        private void AsignColor(Model dbModel, ViewModel model)
        {
            var product = this.Data.Colors.GetById(model.Color.Id);
            dbModel.Color = product;
        }

        private void AsignPackage(Model dbModel, ViewModel model)
        {
            var product = this.Data.Packages.GetById(model.Package.Id);
            dbModel.Package = product;
        }
    }
}