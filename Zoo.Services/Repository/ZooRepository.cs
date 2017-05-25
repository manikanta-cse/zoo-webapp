using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Services.Data;
using Zoo.Services.Models;
using  System.Data.Entity;


namespace Zoo.Services.Repository
{
    public class ZooRepository : IZooRepository, IDisposable
   {
       private ZooContext _zooDbContext;

       public ZooRepository()
       {
           _zooDbContext = new ZooContext();;
       }

       public IEnumerable<Animal> FindAll()
       {

           return _zooDbContext.Animals.Include(a => a.Species).AsEnumerable().Select(animal => new Animal()
           {
               AnimalId = animal.AnimalId,
               SpeciesName = animal.Species.Name,
               AddedDateTime = animal.AddedDateTime,
               Age = CalculateAge(animal.YearOfBirth),
               YearOfBirth =animal.YearOfBirth,
               ModifiedDateTime = animal.ModifiedDateTime,
               AnimalName = animal.AnimalName,
               SpeciesId = animal.SpeciesId

           }).ToList();

       }

        public Animal FindBy(int id)
        {
            return _zooDbContext.Animals.AsEnumerable().Where(i => i.AnimalId == id).Select(animal => new Animal()
            {
                AnimalName = animal.AnimalName,
                Species = animal.Species,
                SpeciesId =animal.SpeciesId,
                AnimalId =animal.AnimalId,
                Age = CalculateAge(animal.YearOfBirth),
                YearOfBirth = animal.YearOfBirth,
                AddedDateTime = animal.AddedDateTime,
                ModifiedDateTime = animal.ModifiedDateTime
            }).FirstOrDefault();



        }

        public bool Insert(Animal animal)
        {

            _zooDbContext.Animals.Add(animal);
            return _zooDbContext.SaveChanges() > 0;
            
        }

        public bool Update(Animal animal)
        {
            
                var animalToUpdate = _zooDbContext.Animals.FirstOrDefault(i => i.AnimalId == animal.AnimalId);
                if (animalToUpdate != null)
                {
                    animalToUpdate.AnimalName = animal.AnimalName;
                    animalToUpdate.YearOfBirth = animal.YearOfBirth;
                    animalToUpdate.SpeciesId = animal.SpeciesId;
                    animalToUpdate.ModifiedDateTime = animal.ModifiedDateTime;
                    return _zooDbContext.SaveChanges() !=-1;
                }
            return false;
        }

        public bool Delete(int id)
        {
             var animalToDelete = _zooDbContext.Animals.FirstOrDefault(i => i.AnimalId == id);
                if (animalToDelete != null)
                {
                    _zooDbContext.Animals.Remove(animalToDelete);
                    return _zooDbContext.SaveChanges() > 0;
                }
            return false;
        }

        public IEnumerable<Species> GetSpecies()
        {
            return _zooDbContext.Species.AsEnumerable();
        }

        public bool DoesExist(string animalName,int animalId, int speciesId)
        {
            var isDuplicate = _zooDbContext.Animals.ToList().Any(i => RemoveWhitespace(i.AnimalName).ToLower() == RemoveWhitespace(animalName).ToLower() && i.SpeciesId == speciesId && i.AnimalId != animalId);
          
            return isDuplicate;
;
        }

        private int CalculateAge(int year)
        {
            var today = DateTime.Today;

            return today.Year - year;
        }

        private static string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
       

        public void Dispose()
        {
            _zooDbContext.Dispose();
            _zooDbContext = null;
        }
               
   }
}
