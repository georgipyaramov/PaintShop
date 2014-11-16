namespace PaintShop.Web.Areas.Administration.Controllers
{
    using PaintShop.Data;
    using PaintShop.Web.Areas.Administration.Controllers.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using PaintShop.Web.Areas.Administration.ViewModels.Packages;
    using Kendo.Mvc.UI;

    using Model = PaintShop.Models.Package;
    using ViewModel = PaintShop.Web.Areas.Administration.ViewModels.Packages.PackageViewModel;

    public class PackagesController : KendoGridAdministrationController
    {
        public PackagesController(IPaintShopData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

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
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        public ActionResult Destroy([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Packages.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override System.Collections.IEnumerable GetData()
        {
            return this.Data.Packages.All()
                       .Project()
                       .To<PackageViewModel>();
        }

        protected override void CreateCustomBindings(object dbModel, object model)
        {
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Packages.GetById(id) as T;
        }
    }
}