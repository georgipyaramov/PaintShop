using PaintShop.Data;
using PaintShop.Models;
using PaintShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaintShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private PaintShopDbContext db;

        public HomeController()
        {
            this.db = new PaintShopDbContext();
        }

        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }
    }
}