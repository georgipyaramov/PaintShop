namespace PaintShop.Web.ViewModels
{
    using System.Collections.Generic;
    using PaintShop.Models;

    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }

        public IEnumerable<Product> TopProducts { get; set; }
    }
}