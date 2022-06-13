using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HowItShouldBeDone.Startup))]
namespace HowItShouldBeDone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
