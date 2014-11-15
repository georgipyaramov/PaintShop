namespace PaintShop.Models
{
    using PaintShop.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductType : DeletableEntity
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
