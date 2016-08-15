using Microsoft.Practices.Unity;
using StockWatch.App_Start;
using StockWatch.Repository;
using System.Web.Http;

namespace StockWatch
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ResolveDependencies(config);
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{query}",
            //    defaults: new { controller = "StockWatch", query = RouteParameter.Optional }
            //);
        }

        private static void ResolveDependencies(HttpConfiguration config)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IStockDataRepository, StockDataRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
