using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventFinder_GC.Startup))]
namespace EventFinder_GC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
