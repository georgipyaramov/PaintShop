namespace PaintShop.Web.ViewModels
{
    using System;

    using PaintShop.Models;
    using PaintShop.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class SimpleCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}