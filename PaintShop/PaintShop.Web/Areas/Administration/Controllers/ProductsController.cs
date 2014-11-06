using PaintShop.Models;
using PaintShop.Web.Areas.Administration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaintShop.Web.Areas.Administration.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductsViewModel> products = new List<ProductsViewModel>
        {
            new ProductsViewModel
            {
                Name = "Travertino",
                Rating = 5,
                Logo = new Picture
                {
                    Name = "TravertinoPic",
                    Path = "~/Imgs/interior-design-1-480x302.jpg"
                }
            },
            new ProductsViewModel
            {
                Name = "Raffaello",
                Rating = 3,
                Logo = new Picture
                {
                    Name = "TravertinoPic",
                    Path = "~/Imgs/interior-design-1-480x302.jpg"
                }
            }
        };
        // GET: Administration/Products
        public ActionResult Index()
        {
            return View(this.products);
        }
    }
}