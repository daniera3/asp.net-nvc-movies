using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.net_nvc_movies.Startup))]
namespace asp.net_nvc_movies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
