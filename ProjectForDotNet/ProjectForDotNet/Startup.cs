using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectForDotNet.Startup))]
namespace ProjectForDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
