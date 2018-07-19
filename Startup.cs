using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace netCore
{
    class Startup
    {
        public Startup()
        {
        }

        public Startup(IHostingEnvironment env)
        {}

        

        #region snippet_Configure
        public void Configure(IApplicationBuilder app)
        {
            var serverAddressesFeature = 
                app.ServerFeatures.Get<IServerAddressesFeature>();

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response
                    .WriteAsync("<!DOCTYPE html><html lang=\"en\"><head>" +
                        "<title></title></head><body><p>Hosted by Kestrel</p>");

                if (serverAddressesFeature != null)
                {
                    await context.Response
                        .WriteAsync("<p>Listening on the following addresses: " +
                            string.Join(", ", serverAddressesFeature.Addresses) +
                            "</p>");
                }

                await context.Response.WriteAsync("<p>Request URL: " +
                    $"{context.Request.GetDisplayUrl()}<p>");
            });
        }
        #endregion
    }
}

