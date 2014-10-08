using System;
using System.Web.Configuration;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Owin;

[assembly: OwinStartup(typeof(KSEPM.Web.Startup))]
namespace KSEPM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            ConfigureAuth(app);
           /* app.Run(context =>
            {
                if (context.Request.Path == new PathString("/fail"))
                {
                    throw new Exception("Random exception");
                }

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            });*/
        }
    }
}