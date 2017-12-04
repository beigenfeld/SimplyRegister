using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimplyRegister.Startup))]
namespace SimplyRegister
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
