using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NSubstitute;
using NUnit.Framework;
using Zoo.Services.Models;
using Zoo.Services.Services;
using ZooWebApp.Controllers;

namespace ZooWebApp.Tests
{
    public class AnimalApiControllerTests
    {
        private readonly AnimaApiController _animaApiController;
        private readonly IAnimalService _animalService;
        private readonly ISpeciesService _speciesService;

        public AnimalApiControllerTests()
        {
            _animalService = Substitute.For<IAnimalService>();
            _speciesService = Substitute.For<ISpeciesService>();
            _animaApiController=new AnimaApiController(_animalService,_speciesService);
            _animaApiController.Request = new HttpRequestMessage();
            _animaApiController.Configuration = new HttpConfiguration();
        }

        [Test]
        public void AnimalApiController_GetAll_Should_Invoke_AnimalService_GetAll_To_Fetch_Animals_And_Should_Return_200_Status_Code()
        {
            _animalService.GetAll().Returns(new AnimalsVm(){ Animals = new List<Animal>(){ new Animal(){ AnimalId = 1}}});
            var result = _animaApiController.GetAllAnimals();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_GetAll_Should_Invoke_AnimalService_GetAll_To_Fetch_Animals_And_Should_Return_400_Status_Code_When_No_Count_Is_0()
        {
            _animalService.GetAll().Returns(new AnimalsVm(){ Animals = new List<Animal>()});
            var result = _animaApiController.GetAllAnimals();
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_GetAnimalById_Should_Invoke_AnimalService_GetById_To_Fetch_Animal_And_Should_Return_200_Status_Code_When_Found()
        {
            _animalService.GetById(1).Returns(new Animal());
            var result = _animaApiController.GetAnimalById(1);
            _animalService.Received().GetById(1);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_GetAnimalById_Should_Invoke_AnimalService_GetById_To_Fetch_Animal_And_Should_Return_400_Status_Code_When_Not_Found()
        {
            _animalService.GetById(1).Returns(a => null);
            var result = _animaApiController.GetAnimalById(1);
            _animalService.Received().GetById(1);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_SaveAnimal_Should_Invoke_AnimalService_AddOrUpdate_To_Save_Animal_And_Should_Return_200_Status_Code_on_Success()
        {   
            var  mockAnimal=new Animal();
            _animalService.AddOrUpdate(mockAnimal).Returns(true);
            var result = _animaApiController.SaveAnimal(mockAnimal);
            _animalService.Received().AddOrUpdate(mockAnimal);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_SaveAnimal_Should_Invoke_AnimalService_AddOrUpdate_To_Save_Animal_And_Should_Return_500_Status_Code_on_Failure()
        {
            var mockAnimal = new Animal();
            _animalService.AddOrUpdate(mockAnimal).Returns(false);
            var result = _animaApiController.SaveAnimal(mockAnimal);
            _animalService.Received().AddOrUpdate(mockAnimal);
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_UpdateAnimal_Should_Invoke_AnimalService_AddOrUpdate_To_Update_Animal_And_Should_Return_200_Status_Code_on_Success()
        {
            var mockAnimal = new Animal(){AnimalId = 1};
            _animalService.AddOrUpdate(mockAnimal).Returns(true);
            var result = _animaApiController.UpdateAnimal(mockAnimal);
            _animalService.Received().AddOrUpdate(mockAnimal);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_UpdateAnimal_Should_Invoke_AnimalService_AddOrUpdate_To_Update_Animal_And_Should_Return_500_Status_Code_on_Failure()
        {
            var mockAnimal = new Animal() { AnimalId = 1 };
            _animalService.AddOrUpdate(mockAnimal).Returns(false);
            var result = _animaApiController.UpdateAnimal(mockAnimal);
            _animalService.Received().AddOrUpdate(mockAnimal);
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_DeleteAnimal_Should_Invoke_AnimalService_Delete_To_Delete_Animal_And_Should_Return_200_Status_Code_on_Success()
        {
            _animalService.Delete(1).Returns(true);
            var result = _animaApiController.DeleteAnimal(1);
            _animalService.Received().Delete(1);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_DeleteAnimal_Should_Invoke_AnimalService_Delete_To_Delete_Animal_And_Should_Return_500_Status_Code_on_Failure()
        {
            _animalService.Delete(0).Returns(false);
            var result = _animaApiController.DeleteAnimal(0);
            _animalService.Received().Delete(0);
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_GetAll_Should_Invoke_SpeciesService_GetAll_To_Fetch_Species_And_Should_Return_200_Status_Code()
        {
            _speciesService.GetAll().Returns(new List<Species>());
            var result = _animaApiController.GetAllSpecies();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_DoesAnimalExist_Should_Invoke_AnimalService_DoesAnimalExist_And_Should_Return_200_Status_Code_If_Animal_Doesnt_Exist()
        {
            _animalService.DoesAnimalExist("Lion",0,1).Returns(false);
            var result = _animaApiController.DoesAnimalExist("Lion", 0, 1);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void AnimalApiController_DoesAnimalExist_Should_Invoke_AnimalService_DoesAnimalExist_And_Should_Return_300_Status_Code_If_Animal_Already_Exist()
        {
            _animalService.DoesAnimalExist("Lion", 0, 1).Returns(true);
            var result = _animaApiController.DoesAnimalExist("Lion", 0, 1);
            Assert.AreEqual(HttpStatusCode.Ambiguous, result.StatusCode);
        }


    }


}