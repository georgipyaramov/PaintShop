using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaintShop.Web.Areas.Employees.ViewModels.Calculator
{
    public class CalculationParametersInputModel
    {
        public int Product { get; set; }

        public int Color { get; set; }

        public double Quadrature { get; set; }
    }
}