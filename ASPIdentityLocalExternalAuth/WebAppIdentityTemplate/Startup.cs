using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppIdentityTemplate.Startup))]
namespace WebAppIdentityTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
