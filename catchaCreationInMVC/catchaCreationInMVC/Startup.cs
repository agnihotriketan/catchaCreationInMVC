using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(catchaCreationInMVC.Startup))]
namespace catchaCreationInMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
