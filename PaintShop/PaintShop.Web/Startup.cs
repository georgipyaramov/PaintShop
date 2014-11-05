using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaintShop.Web.Startup))]
namespace PaintShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
