using System.Web.Http;
using System.Web.Http.Dispatcher;
using StructureMap.Pipeline;
using ZooWebApp.Dependency;

namespace ZooWebApp
{
    public class DependencyConfig
    {
        public static void Config(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapHttpControllerActivator(config));
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
        }

        public static void CleanUp()
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }
    }
}