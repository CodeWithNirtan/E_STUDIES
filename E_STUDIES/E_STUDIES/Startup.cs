using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_STUDIES.Startup))]
namespace E_STUDIES
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
