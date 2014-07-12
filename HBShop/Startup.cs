using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HBShop.Startup))]
namespace HBShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
