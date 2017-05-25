using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zoo.Services.Models;
using Zoo.Services.Services;

namespace ZooWebApp.Controllers
{
    [RoutePrefix("api/services/zoo")]
    public class AnimaApiController : ApiController
    {
        private readonly IAnimalService _animalService;
        private readonly ISpeciesService _speciesService;
        public AnimaApiController(IAnimalService animalService,ISpeciesService speciesService)
        {
            
            _animalService = animalService;
            _speciesService = speciesService;
        }

        [HttpGet]
        [Route("animals")]
        public HttpResponseMessage GetAllAnimals()
        {
            var animals = _animalService.GetAll();
            if (animals == null || !animals.Animals.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"Oops! There are no animals");
            }
            return Request.CreateResponse(HttpStatusCode.OK, animals);
        }

        [HttpGet]
        [Route("animal/{animalId}")]
        public HttpResponseMessage GetAnimalById(int animalId = 0)
        {
            var animal = _animalService.GetById(animalId);
            if (animal == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Oops! Animal not found."));

            return Request.CreateResponse(HttpStatusCode.OK, animal);
        }

        [HttpPost]
        [Route("save")]
        public HttpResponseMessage SaveAnimal(Animal animal)
        {
            var result = _animalService.AddOrUpdate(animal);

            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Sorry, There was an error while saving Animal");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Animal Saved Successfully!");
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateAnimal(Animal animal)
        {
            var result = _animalService.AddOrUpdate(animal);

            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Sorry, There was an error while updating Animal");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Animal Updated Successfully!");
        }

        [HttpDelete]
        [Route("remove/{animalId}")]
        public HttpResponseMessage DeleteAnimal(int animalId = 0)
        {
            var result = _animalService.Delete(animalId);

            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Sorry, There was an error while deleting Animal");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Animal Deleted Successfully!");
        }

        [HttpGet]
        [Route("animal/{animalName}/{animalId}/{speciesId}")]
        public HttpResponseMessage DoesAnimalExist(string animalName, int animalId, int speciesId = 0)
        {
            var isDuplicate = _animalService.DoesAnimalExist(animalName,animalId,speciesId);
            if (isDuplicate)
                return Request.CreateErrorResponse(HttpStatusCode.Ambiguous, string.Format("Animal with Name {0} and Selected Species already exists.", animalName));

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("species")]
        public HttpResponseMessage GetAllSpecies()
        {
            var species= _speciesService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, species);
        }

    }
}
