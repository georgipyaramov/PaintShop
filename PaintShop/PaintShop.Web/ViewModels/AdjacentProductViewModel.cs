using PaintShop.Models;
using PaintShop.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaintShop.Web.ViewModels
{
    public class AdjacentProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}