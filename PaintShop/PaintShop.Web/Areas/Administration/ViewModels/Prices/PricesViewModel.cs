namespace PaintShop.Web.Areas.Administration.ViewModels.Prices
{
    using PaintShop.Models;
    using PaintShop.Web.Areas.Administration.ViewModels.Base;
    using PaintShop.Web.Areas.Administration.ViewModels.Colors;
    using PaintShop.Web.Areas.Administration.ViewModels.Packages;
    using PaintShop.Web.Infrastructure.Mapping;
    using PaintShop.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class PricesViewModel : AdministrationViewModel, IMapFrom<ProductColorPackagePrice>
    {
        public int Id { get; set; }

        [UIHint("BasicProductEditor")]
        public BasicProductViewModel Product { get; set; }

        [UIHint("ColorEditor")]
        public ColorViewModel Color { get; set; }

        [UIHint("PackageEditor")]
        public PackageViewModel Package { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}