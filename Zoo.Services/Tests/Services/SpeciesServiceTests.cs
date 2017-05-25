using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Zoo.Services.Models;
using Zoo.Services.Repository;
using Zoo.Services.Services;

namespace Zoo.Services.Tests.Services
{
   public class SpeciesServiceTests
    {
       private readonly IZooRepository _zooRepository;
       private readonly ISpeciesService _speciesService;
        public SpeciesServiceTests()
        {
            _zooRepository = Substitute.For<IZooRepository>();
            _speciesService=new SpeciesService(_zooRepository);
        }

        [Test]
        public void AnimalService_GetAll_Should_Invoke_ZooRepository_GetSpecies_To_Fetch_ResultSet()
        {
            _zooRepository.GetSpecies().Returns(new List<Species>());
            _speciesService.GetAll();
            _zooRepository.Received().GetSpecies();
        }

    }
}
