using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyAlmaLibrary.Startup))]
namespace MyAlmaLibrary
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
