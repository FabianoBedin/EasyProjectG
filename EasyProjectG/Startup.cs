using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyProjectG.Startup))]
namespace EasyProjectG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
