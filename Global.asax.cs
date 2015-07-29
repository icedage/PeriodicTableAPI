using Castle.MicroKernel.Registration;
using Castle.Windsor;
using HostelBookers.Pricing.WebApi.Infrastructure.Windsor;
using PeriodicTableAPI.Installers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PeriodicTableAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private static WindsorContainer _container;


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            _container = new WindsorContainer();
            BootstrapWindsor();
        }

        private static void BootstrapWindsor()
        {
            //Add Web API controllers into CastleWindsor
            _container.Register(AllTypes.FromThisAssembly()
                                        .BasedOn<IHttpController>()
                                        .WithService.DefaultInterfaces()
                                        .Configure(c => c.LifestylePerWebRequest()));

            _container.Install(new PresentationInstaller());

            //Tie Castle.Windsor to WebAPI
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                                                               new WindsorHttpControllerActivator(_container));
        }
    }
}