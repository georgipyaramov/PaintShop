namespace PaintShop.Web.ViewModels
{
    using System.Collections.Generic;

    using PaintShop.Models;
    using PaintShop.Web.Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Picture Logo { get; set; }

        public IEnumerable<Picture> Pictures { get; set; }
    }
}