namespace PaintShop.Web.Controllers.Base
{
    using PaintShop.Data;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        public BaseController(IPaintShopData data)
        {
            this.Data = data;
        }

        public IPaintShopData Data { get; set; }
        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}