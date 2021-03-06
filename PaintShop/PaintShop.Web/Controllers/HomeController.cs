﻿namespace PaintShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PaintShop.Data;
    using PaintShop.Models;
    using PaintShop.Web.Controllers.Base;
    using PaintShop.Web.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(IPaintShopData data)
            :base(data)
        {
        }
        
        public ActionResult Index()
        {
            var products = this.Data.Products.All().Where(p => p.Rating == 5).ToList();

            var viewModel = new HomeViewModel();
            viewModel.TopProducts = products;

            return View(viewModel);
        }

        public ActionResult TopProducts(int? id)
        {
            Product product = null;

            if (id != null)
            {
                product = this.Data.Products.GetById(id);
            }
            else
            {
                product = this.Data.Products.All().Where(p => p.Rating == 5).FirstOrDefault();
            }
            
            return PartialView("_PictureGridPartial", product.Pictures.ToList());
        }
    }
}