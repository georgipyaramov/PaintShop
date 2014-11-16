namespace PaintShop.Web.Areas.Employees.ViewModels.Calculator
{
    using PaintShop.Models;
    using PaintShop.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ColorViewModel : IMapFrom<Color>
    {
        public int Id { get; set; }

        [Required]
        public string ColorIdentificator { get; set; }

        public string RgbCode { get; set; }
    }
}