namespace PaintShop.Models
{
    using PaintShop.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class Color : DeletableEntity
    {
        public Color()
        {
        }

        public int Id { get; set; }

        [Required]
        public string ColorIdentificator { get; set; }

        public string RgbCode { get; set; }

    }
}
