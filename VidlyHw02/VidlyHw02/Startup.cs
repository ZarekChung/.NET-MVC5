using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyHw02.Startup))]
namespace VidlyHw02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
