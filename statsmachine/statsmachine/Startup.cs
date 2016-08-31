using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(statsmachine.Startup))]
namespace statsmachine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
