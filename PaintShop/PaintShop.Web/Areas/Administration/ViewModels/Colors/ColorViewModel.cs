namespace PaintShop.Web.Areas.Administration.ViewModels.Colors
{
    using PaintShop.Models;
    using PaintShop.Web.Areas.Administration.ViewModels.Base;
    using PaintShop.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class ColorViewModel: AdministrationViewModel, IMapFrom<Color>
    {
        public int Id { get; set; }

        [Required]
        public string ColorIdentificator { get; set; }

        public string RgbCode { get; set; }
        
    }
}