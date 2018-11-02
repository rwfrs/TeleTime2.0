using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(TeleTime.Startup))]
namespace TeleTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
