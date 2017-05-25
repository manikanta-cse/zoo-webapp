using System.Collections.Generic;
using System.Linq;

namespace Zoo.Services.Models
{
    public class AnimalsVm
    {
        public IEnumerable<Animal> Animals { get; set; }

        public int AverageAge
        {
            get { return (int)Animals.Average(i => i.Age); }
        }
    }
}
