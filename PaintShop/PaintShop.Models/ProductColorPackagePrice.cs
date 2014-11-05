namespace PaintShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductColorPackagePrice
    {
        public ProductColorPackagePrice()
        {
        }

        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Key, Column(Order = 1)]
        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        [Key, Column(Order = 2)]
        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}