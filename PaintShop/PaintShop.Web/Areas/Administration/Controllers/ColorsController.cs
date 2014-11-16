namespace PaintShop.Web.Areas.Administration.Controllers
{
    using Kendo.Mvc.UI;
    using PaintShop.Data;
    using PaintShop.Web.Areas.Administration.Controllers.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using PaintShop.Web.Areas.Administration.ViewModels.Colors;

    using Model = PaintShop.Models.Color;
    using ViewModel = PaintShop.Web.Areas.Administration.ViewModels.Colors.ColorViewModel;

    public class ColorsController : KendoGridAdministrationController
    {
        public ColorsController(IPaintShopData data) 
            : base(data)
        {
        }

        // GET: Administration/Colors
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
                this.Data.Colors.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override System.Collections.IEnumerable GetData()
        {
            return this.Data.Colors.All()
                       .Project()
                       .To<ColorViewModel>();
        }

        protected override void CreateCustomBindings(object dbModel, object model)
        {
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Colors.GetById(id) as T;
        }
    }
}