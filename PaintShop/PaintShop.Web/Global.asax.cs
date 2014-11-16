﻿using PaintShop.Web.Infrastructure.CustomModelBinders;
using PaintShop.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PaintShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            ModelBinders.Binders.Add(typeof(DateTime), new JsonDateTimeModelBinder());
            ModelBinders.Binders.Add(typeof(Nullable<DateTime>), new JsonDateTimeModelBinder());
            AutoMapperConfig.Execute();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
