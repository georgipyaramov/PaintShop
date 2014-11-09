namespace PaintShop.Web.Controllers
{
    using PaintShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

    public class BaseController : Controller
    {
        public BaseController(IPaintShopData data)
        {
            this.Data = data;
        }

        public IPaintShopData Data { get; set; }
    }
}