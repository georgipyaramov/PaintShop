namespace PaintShop.Web.Areas.Employees.ViewModels.Calculator
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CalculationParametersInputModel
    {
        public int Product { get; set; }

        public int Color { get; set; }

        [Required]
        public double Quadrature { get; set; }
    }
}