namespace PaintShop.Web.Areas.Administration.ViewModels
{
    using PaintShop.Models;

    public class ProductsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Picture Logo { get; set; }

        public int Rating { get; set; }
    }
}