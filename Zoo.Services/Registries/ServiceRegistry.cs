using StructureMap.Configuration.DSL;
using Zoo.Services.Repository;
using Zoo.Services.Services;

namespace Zoo.Services.Registries
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<IZooRepository>().Use<ZooRepository>();
            For<IAnimalService>().Use<AnimalService>();
            For<ISpeciesService>().Use<SpeciesService>();
        }
    }
}
