using System;
using System.Linq;
using Zoo.Services.Models;
using Zoo.Services.Repository;

namespace Zoo.Services.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IZooRepository _zooRepository;
        public AnimalService(IZooRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }

        public AnimalsVm GetAll()
        {
            var animals = _zooRepository.FindAll().AsEnumerable();
            var animalsVm = new AnimalsVm { Animals = animals };

            return animalsVm;
        }

        public Animal GetById(int id = 0)
        {
            if (id == 0)
            {
                return new Animal();
            }
            return _zooRepository.FindBy(id);
        }

        public bool AddOrUpdate(Animal animal)
        {
            if (animal.AnimalId == 0)
            {
                animal.AddedDateTime=DateTime.Now;
                return _zooRepository.Insert(animal);
            }
            animal.ModifiedDateTime=DateTime.Now;
            return _zooRepository.Update(animal);
        }

        public bool Delete(int id = 0)
        {
            return id != 0 && _zooRepository.Delete(id);

        }
        public bool DoesAnimalExist(string animalName, int animalId = 0, int speciesId = 0)
        {
            return animalName != string.Empty && speciesId != 0 && _zooRepository.DoesExist(animalName, animalId, speciesId);
        }

    }
}
