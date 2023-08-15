using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using Booking.Core.Interfaces;
using Booking.Core.Services;
using Booking.Core.Repositories;

namespace Booking.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ConfigureDependencyInjection();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureDependencyInjection()
        {
            var container = new Container();

            // To use the "Scoped" lifestyle, we must set a default.  Otherwise, it will throw an exception.
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register all the application's dependencies that will be injected
            container.Register<IBookingService, BookingService>(Lifestyle.Scoped);
            container.Register<IBookingRepository, BookingRepository>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            // Create the service that the application will use to resolve all injected dependencies
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
