using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel2.Startup))]
namespace Hotel2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
