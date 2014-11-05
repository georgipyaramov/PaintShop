namespace PaintShop.Web.ViewModels
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.TopProducts = new List<string>()
            {
                "Aureum",
                "Kreos Fil Pose",
                "Imperium",
                "Raffaello",
                "Travertino Romano",
                "Ottocento"
            };
        }

        public IEnumerable<string> TopProducts { get; set; }
    }
}