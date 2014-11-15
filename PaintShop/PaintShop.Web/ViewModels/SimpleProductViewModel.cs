namespace PaintShop.Web.ViewModels
{
    using PaintShop.Models;
    using PaintShop.Web.Infrastructure.Mapping;
    using PaintShop.Web.ViewModels;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Script.Serialization;
    using System.Collections.Generic;
    using AutoMapper;

    public class SimpleProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ProductIdentificator { get; set; }

        [Required]
        public double Consumtion { get; set; }

        public string Description { get; set; }

        public string Effect { get; set; }

        [Required]
        [UIHint("CategoryViewModel")]
        public SimpleCategoryViewModel Category { get; set; }

        [Required]
        [UIHint("TypeViewModel")]
        public SimpleProductTypeViewModel ProductType { get; set; }

        [UIHint("AjacentProductsEditor")]
        public IList<AdjacentProductViewModel> AdjacentProducts { get; set; }
    }
}