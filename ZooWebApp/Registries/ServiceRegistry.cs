using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using Zoo.Services.Services;

namespace ZooWebApp.Registries
{
    public class ServiceRegistry:Registry
    {
        public ServiceRegistry()
        {
            For<IAnimalService>().Use<AnimalService>();
        }
    }
}