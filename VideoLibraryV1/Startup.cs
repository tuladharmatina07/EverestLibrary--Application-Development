using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoLibraryV1.Startup))]
namespace VideoLibraryV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
