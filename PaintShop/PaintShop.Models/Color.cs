namespace PaintShop.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Color
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
