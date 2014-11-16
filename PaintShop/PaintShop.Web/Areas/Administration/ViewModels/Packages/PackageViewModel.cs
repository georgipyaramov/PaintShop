namespace PaintShop.Web.Areas.Administration.ViewModels.Packages
{
    using PaintShop.Models;
    using PaintShop.Web.Areas.Administration.ViewModels.Base;
    using PaintShop.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class PackageViewModel : AdministrationViewModel, IMapFrom<Package>
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}