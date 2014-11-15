namespace PaintShop.Web.Controllers.Base
{
    using PaintShop.Data;
using System;
using System.Collections.Generic;
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
    }
}