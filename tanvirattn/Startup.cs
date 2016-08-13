using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tanvirattn.Startup))]
namespace tanvirattn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
