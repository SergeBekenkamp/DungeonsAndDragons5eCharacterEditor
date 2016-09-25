using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DnD.Datalayer.Context;
using DnD.Web;
using DungeonsAndDragons.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(DungeonsAndDragons.Startup))]

namespace DungeonsAndDragons
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            var container = ConfigureAutoFac.ConfigureMvc();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //Dit op Configure laten staan, dit wordt namelijk niet in web requests gebruikt
            // Remove the old formatter, add the new one.
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            config.Formatters.Remove(config.Formatters.JsonFormatter);
            config.Formatters.Add(formatter);
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            WebApiConfig.Register(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(DnDContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //var OAuthServerOptions = new OAuthAuthorizationServerOptions
            //{
            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/token"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            //    Provider = new SimpleAuthorizationServerProvider()
            //};

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieHttpOnly = false,
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //ExpireTimeSpan =  TimeSpan.FromDays(2),
                CookieSecure = CookieSecureOption.Always,
                //Provider = new SimpleCookieAuthorizationServerProvider(),
                AuthenticationMode = AuthenticationMode.Active
            });


            // app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
