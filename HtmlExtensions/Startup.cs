using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HtmlExtensions.Startup))]
namespace HtmlExtensions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
