namespace PaintShop.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Package
    {
        public Package()
        {
        }

        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
