using System.Collections.Generic;
using Zoo.Services.Models;

namespace Zoo.Services.Services
{
    public interface IAnimalService
    {
        AnimalsVm GetAll();
        Animal GetById(int id=0);
        bool AddOrUpdate(Animal animal);
        bool Delete(int id=0);
        bool DoesAnimalExist(string animalName, int animalId=0,int speciesId = 0);
    }
}