using PaintShop.Models;
using PaintShop.Web.Areas.Administration.ViewModels.Base;
using PaintShop.Web.Infrastructure.Mapping;
using PaintShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaintShop.Web.Areas.Administration.ViewModels.Products
{
    public class ProductViewModel : AdministrationViewModel, IMapFrom<Product>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string ProductIdentificator { get; set; }

        [Required]
        public double Consumtion { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Effect { get; set; }

        [Required]
        [UIHint("CategoryViewModel")]
        public SimpleCategoryViewModel Category { get; set; }

        [Required]
        [UIHint("TypeViewModel")]
        public SimpleProductTypeViewModel ProductType { get; set; }

        [UIHint("AjacentProductsEditor")]
        public IList<AdjacentProductViewModel> AdjacentProducts { get; set; }
    }
}