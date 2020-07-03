using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using apsys.identityserver.owin;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(apsys.imbera.identityserverclient.webapi.Startup))]

namespace apsys.imbera.identityserverclient.webapi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure the webapi in order to verify the authentication token
            var identityServerUrl = $"{ConfigurationManager.AppSettings["identityServerUrl"]}/identity";
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = identityServerUrl
            });
            app.ConfigureIdentityServerClients(
                cfg => {
                }
            );

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

    }
}
