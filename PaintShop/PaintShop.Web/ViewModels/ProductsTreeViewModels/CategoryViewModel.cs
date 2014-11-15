namespace PaintShop.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using PaintShop.Models;
    using PaintShop.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CategoryViewModel : SimpleProductTypeViewModel, IMapFrom<Category>
    {
        public IEnumerable<ProductTypeViewModel> Types { get; set; }
    }
}