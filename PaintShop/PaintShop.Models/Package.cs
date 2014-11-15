namespace PaintShop.Models
{
    using PaintShop.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class Package : DeletableEntity
    {
        public Package()
        {
        }

        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
