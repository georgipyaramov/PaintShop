namespace PaintShop.Models
{
    using PaintShop.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : DeletableEntity
    {

        public Category()
        {
            this.Products = new HashSet<Product>();
            this.Types = new HashSet<ProductType>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ProductType> Types { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
