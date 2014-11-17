namespace PaintShop.Web.Areas.Employees.ViewModels.Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using PaintShop.Web.ViewModels;

    public class CalculatorProductResultViewModel
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Identificator { get; set; }

        public string ColorIdentificator { get; set; }

        public int LitersNeeded { get; set; }

        public decimal TotalPrice { get; set; }
    }
}