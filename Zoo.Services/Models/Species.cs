using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zoo.Services.Models
{
    public class Species
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpeciesId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
