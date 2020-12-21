using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternetBasedDiscussionForum.Startup))]
namespace InternetBasedDiscussionForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
