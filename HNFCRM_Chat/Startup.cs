using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HNFCRM_Chat.Startup))]
namespace HNFCRM_Chat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
