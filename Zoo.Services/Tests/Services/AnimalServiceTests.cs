using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Zoo.Services.Models;
using Zoo.Services.Repository;
using Zoo.Services.Services;

namespace Zoo.Services.Tests.Services
{
   public class AnimalServiceTests
   {
       private readonly IZooRepository _zooRepository;
       private readonly IAnimalService _animalService;
        public AnimalServiceTests()
        {
            _zooRepository = Substitute.For<IZooRepository>();
            _animalService=new AnimalService(_zooRepository);
        }

       [Test]
        public void AnimalService_GetAll_Should_Invoke_ZooRepository_FindAll_To_Fetch_ResultSet()
       {
            var mockAnimals= new List<Animal>();
           _zooRepository.FindAll().Returns(mockAnimals.AsQueryable());
           _animalService.GetAll();
           _zooRepository.Received().FindAll();
       }

       [Test]
       public void AnimalService_GetById_Should_Invoke_ZooRepository_FindBy_To_Fetch_Result()
       {
           var mockAnimal = new Animal() {AnimalId = 1};
           _zooRepository.FindBy(1).Returns(mockAnimal);
           var result=_animalService.GetById(1);
           _zooRepository.Received().FindBy(1);
           Assert.AreEqual(mockAnimal,result);

       }

       [Test]
       public void AnimalService_GetById_Should_Invoke_ZooRepository_FindBy_To_Fetch_Result_And_Should_Return_Default_When_Id_Is_Zero()
       {
           var mockAnimal = new Animal();
           var result= _animalService.GetById(0);
           Assert.IsTrue(result.Equals(mockAnimal));
       }

       [Test]
       public void AnimalService_AddOrUpdate_Should_Invoke_ZooRepository_Insert_For_Insertion_And_Should_Return_True_On_Success()
       {
           var mockAnimal = new Animal();
           _zooRepository.Insert(mockAnimal).Returns(true);
           var result = _animalService.AddOrUpdate(mockAnimal);
           _zooRepository.Received().Insert(mockAnimal);
           Assert.AreEqual(result, true);
       }

       [Test]
       public void AnimalService_AddOrUpdate_Should_Invoke_ZooRepository_Insert_For_Insertion_And_Should_Return_False_On_Failure()
       {
           var mockAnimal = new Animal();
           _zooRepository.Insert(mockAnimal).Returns(false);
           var result = _animalService.AddOrUpdate(mockAnimal);
           _zooRepository.Received().Insert(mockAnimal);
           Assert.AreEqual(result, false);
       }

       [Test]
       public void AnimalService_AddOrUpdate_Should_Invoke_ZooRepository_Update_For_Updation_And_Should_Return_True_On_Success()
       {
           var mockAnimal = new Animal() { AnimalId = 1 };
           _zooRepository.Update(mockAnimal).Returns(true);
           var result = _animalService.AddOrUpdate(mockAnimal);
           _zooRepository.Received().Update(mockAnimal);
           Assert.AreEqual(result, true);
       }

       [Test]
       public void AnimalService_AddOrUpdate_Should_Invoke_ZooRepository_Update_For_Updation_And_Should_Return_False_On_Failure()
       {
           var mockAnimal = new Animal(){ AnimalId = 1};
           _zooRepository.Update(mockAnimal).Returns(false);
           var result = _animalService.AddOrUpdate(mockAnimal);
           _zooRepository.Received().Update(mockAnimal);
           Assert.AreEqual(result, false);
       }

       [Test]
       public void AnimalService_Delete_Should_Invoke_ZooRepository_Delete_For_Deletion_And_Should_Return_True_On_Success()
       {
          _zooRepository.Delete(1).Returns(true);
           var result = _animalService.Delete(1);
           _zooRepository.Received().Delete(1);
           Assert.AreEqual(result, true);
       }

       [Test]
       public void AnimalService_Delete_Should_Invoke_ZooRepository_Delete_For_Deletion_And_Should_Return_False_When_Id_Is_0()
       {
           _zooRepository.Delete(1).Returns(false);
           var result = _animalService.Delete(1);
           _zooRepository.Received().Delete(1);
           Assert.AreEqual(result, false);
       }

       [Test]
       public void AnimalService_DeosAnimalExist_Should_Invoke_ZooRepository_DoesExist_For_To_Check_Does_Animal_Already_Exists_If_So_Should_Return_True()
       {
           _zooRepository.DoesExist("Lion",0,1).Returns(true);
           var result = _animalService.DoesAnimalExist("Lion", 0, 1);
           _zooRepository.Received().DoesExist("Lion", 0, 1);
           Assert.AreEqual(result, true);
       }

       [Test]
       public void AnimalService_DeosAnimalExist_Should_Invoke_ZooRepository_DoesExist_For_To_Check_Does_Animal_Already_Exists_If_Not_Should_Return_False()
       {
           _zooRepository.DoesExist("Lion", 0, 1).Returns(false);
           var result = _animalService.DoesAnimalExist("Lion", 0, 1);
           _zooRepository.Received().DoesExist("Lion", 0, 1);
           Assert.AreEqual(result, false);
       }
    }
}
