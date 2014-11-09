using Kendo.Mvc.UI;
using PaintShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaintShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private PaintShopDbContext db = new PaintShopDbContext();

        // GET: Products
        public ActionResult Index()
        {

            return View();
        }

    }
}