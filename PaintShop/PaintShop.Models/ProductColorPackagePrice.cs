namespace PaintShop.Models
{
    using PaintShop.Contracts;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductColorPackagePrice : DeletableEntity
    {
        public ProductColorPackagePrice()
        {
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}