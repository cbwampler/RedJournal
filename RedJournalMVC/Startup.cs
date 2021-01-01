using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedJournalMVC.Startup))]
namespace RedJournalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
