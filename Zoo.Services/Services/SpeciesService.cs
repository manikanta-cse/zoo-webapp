using System.Collections.Generic;
using Zoo.Services.Repository;


namespace Zoo.Services.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly IZooRepository _zooRepository;

        public SpeciesService(IZooRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }
        public IEnumerable<Models.Species> GetAll()
        {
            return _zooRepository.GetSpecies();
        }


    }
}
