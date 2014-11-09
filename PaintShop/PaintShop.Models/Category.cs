namespace PaintShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {

        public Category()
        {
            this.Products = new HashSet<Product>();
            this.Types = new HashSet<Type>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Type> Types { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
