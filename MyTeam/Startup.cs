using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTeam.Startup))]
namespace MyTeam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
