namespace PaintShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using PaintShop.Data;
    using PaintShop.Web.ViewModels;
    using PaintShop.Models;
    using PaintShop.Web.Controllers.Base;


    public class ProductsController : BaseController
    {

        public ProductsController(IPaintShopData data) 
            : base(data)
        {
        }

        public ActionResult Index(int? id)
        {
            var user = User;

            var categories = this.Data.Categories.All()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Types = c.Types.Select(t => new ProductTypeViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Products = t.Products
                            .Where(p => p.CategoryId == c.Id)
                            .Select(p => new ProductViewModel() 
                            {
                                Id = p.Id,
                                Name = p.Name
                            })
                    })
                });


            return View(categories);
        }

        public ActionResult Description(int? id)
        {
            var dbProduct = this.Data.Products.GetById(id);
            var product = Mapper.Map<Product, ProductViewModel>(dbProduct);


            return PartialView("_ProductDescription", product);
        }
    }
}