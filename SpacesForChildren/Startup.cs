using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpacesForChildren.Startup))]
namespace SpacesForChildren
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
