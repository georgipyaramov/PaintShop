namespace PaintShop.Web.ViewModels
{
    using System.Collections.Generic;

    using PaintShop.Models;
    using PaintShop.Web.Infrastructure.Mapping;

    public class ProductTypeViewModel : SimpleProductTypeViewModel, IMapFrom<ProductType>
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}