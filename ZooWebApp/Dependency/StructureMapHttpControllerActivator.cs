using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using ZooWebApp.Container;

namespace ZooWebApp.Dependency
{
    public class StructureMapHttpControllerActivator : IHttpControllerActivator
    {
        public StructureMapHttpControllerActivator(HttpConfiguration configuration) { }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return ContainerManager.Current.GetInstance(controllerType) as IHttpController;
        }
    }
}