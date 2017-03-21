using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSDHRProject.Startup))]
namespace CSDHRProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
