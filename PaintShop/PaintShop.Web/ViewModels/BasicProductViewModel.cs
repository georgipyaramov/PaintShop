namespace PaintShop.Web.ViewModels
{
    using PaintShop.Models;
    using PaintShop.Web.Infrastructure.Mapping;

    public class BasicProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}