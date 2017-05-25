using System.Collections.Generic;
using Zoo.Services.Models;

namespace Zoo.Services.Repository
{
    public interface IZooRepository
    {

        IEnumerable<Animal> FindAll();

        Animal FindBy(int id);

        bool Insert(Animal animal);
        bool Update(Animal animal);
        bool Delete(int id);
        bool DoesExist(string animalName,int animalId ,int speciesId);
        IEnumerable<Species> GetSpecies();
    }
}
