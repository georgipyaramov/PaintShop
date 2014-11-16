﻿namespace PaintShop.Web.Areas.Administration.Controllers.Base
{
    using System.Linq;
    using System.Collections;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using System.Data.Entity;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PaintShop.Data;
    using PaintShop.Contracts;
    using PaintShop.Web.Areas.Administration.ViewModels;
    using PaintShop.Web.ViewModels;
    using PaintShop.Web.Areas.Administration.ViewModels.Base;

    public abstract class KendoGridAdministrationController : AdministrationController
    {
        public KendoGridAdministrationController(IPaintShopData data)
            : base(data)
        {
        }

        protected abstract IEnumerable GetData();

        protected abstract void CreateCustomBindings(object dbModel, object model);

        protected abstract T GetById<T>(object id) where T : class;

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var result =
                this.GetData()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<T>(model);
                this.CreateCustomBindings(dbModel, model);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : AuditInfo
            where TViewModel : AdministrationViewModel
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById<TModel>(id);
                Mapper.Map<TViewModel, TModel>(model, dbModel);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);
                model.ModifiedOn = dbModel.ModifiedOn;
                this.Data.SaveChanges();
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private void ChangeEntityStateAndSave(object dbModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dbModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}