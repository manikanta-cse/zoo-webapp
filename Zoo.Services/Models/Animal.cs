using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zoo.Services.Models
{
    public class Animal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int YearOfBirth { get; set; }
        [NotMapped]
        public int Age { get; set; }
        public int SpeciesId { get; set; }
        [NotMapped]
        public string SpeciesName { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public virtual Species Species { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Animal)obj;

            return AnimalId == other.AnimalId
                && AddedDateTime == other.AddedDateTime
                && Age == other.Age
                && AnimalName == other.AnimalName
                && SpeciesId == other.SpeciesId
                && YearOfBirth == other.YearOfBirth;
        }
    }

}
