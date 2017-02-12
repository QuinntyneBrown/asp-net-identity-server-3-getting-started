using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Unity.WebApi;

[assembly: OwinStartup(typeof(AspNetIdentityServerGettingStarted.Startup))]

namespace AspNetIdentityServerGettingStarted
{
    public class Startup
    {
        private static readonly Action<HttpConfiguration> configurationCallback = (config) =>
        {
            config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetContainer());
            config.MapHttpAttributeRoutes();
        };

        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(configurationCallback);
        }
    }
}


