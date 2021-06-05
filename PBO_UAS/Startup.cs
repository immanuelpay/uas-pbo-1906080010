using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PBO_UAS.Startup))]
namespace PBO_UAS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
