using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tripadvisor.Startup))]
namespace Tripadvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
