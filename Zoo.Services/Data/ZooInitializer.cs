using System;
using System.Collections.Generic;
using Zoo.Services.Models;

namespace Zoo.Services.Data
{
    public class ZooInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ZooContext>
    {
        protected override void Seed(ZooContext context)
        {
            var species= new List<Species>
            {
                new Species(){ Name = "Diceros bicornis"},
                new Species(){ Name = "Eretmochelys imbricata"},
                new Species(){ Name = "Panthera uncia"},
                new Species(){ Name = "Ailuropoda melanoleuca"},
                new Species(){ Name = "Panthera leo"},
                new Species(){ Name = "Pandion haliaetus"},
                new Species(){ Name = "Natrix natrix"},
                new Species(){ Name = "Pan troglodytes"},
                new Species(){ Name = "Panthera tigris"},
                new Species(){ Name = "Ailurus fulgens"},
                new Species(){ Name = "Acinonyx jubatus"},
                new Species(){ Name = "Elephas maximus"},
                new Species(){ Name = "Pan paniscus"},
                new Species(){ Name = "Puma concolor"},
                new Species(){ Name = "Tyto alba"}
            };

            species.ForEach(sp=>context.Species.Add(sp));
            context.SaveChanges();

            var animals = new List<Animal>
            {
                new Animal(){AnimalName = "Animal",YearOfBirth = 1981,AddedDateTime = DateTime.Now,SpeciesId = 1}
            };

            animals.ForEach(a=>context.Animals.Add(a));
            context.SaveChanges();
        }
    }
}
