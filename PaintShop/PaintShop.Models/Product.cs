namespace PaintShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        private ICollection<Product> adjacentProducts;

        private ICollection<Picture> pictures;

        public Product()
        {
            this.adjacentProducts = new HashSet<Product>();
            this.pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }

        [Required]
        public string ProductIdentificator { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public int TypeId { get; set; }

        public virtual Type Type { get; set; }

        public double Consumtion { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public string Effect { get; set; }

        public virtual Picture Logo { get; set; }

        public virtual ICollection<Product> AdjacentProducts
        {
            get
            {
                return this.adjacentProducts;
            }
            set
            {
                this.adjacentProducts = value;
            }
        }

        public virtual ICollection<Picture> Pictures
        {
            get
            {
                return this.pictures;
            }
            set
            {
                this.pictures = value;
            }
        }
    }
}