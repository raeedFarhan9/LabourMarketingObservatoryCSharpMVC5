using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaburMarketObservatoryMVC5.Startup))]
namespace LaburMarketObservatoryMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
