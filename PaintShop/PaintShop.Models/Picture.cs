using PaintShop.Contracts;
namespace PaintShop.Models
{
    public class Picture : DeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsLogo { get; set; }
    }
}
