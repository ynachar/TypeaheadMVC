using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TypeAheadControl.Startup))]
namespace TypeAheadControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
