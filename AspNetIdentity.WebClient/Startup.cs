using Microsoft.Owin;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Owin;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(AspNetIdentity.WebClient.Startup))]
namespace AspNetIdentity.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
