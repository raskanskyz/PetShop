using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetShopMVC.Startup))]
namespace PetShopMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
