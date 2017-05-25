using System.Collections.Generic;
using Zoo.Services.Models;

namespace Zoo.Services.Services
{
    public interface ISpeciesService
    {
        IEnumerable<Species> GetAll();
    }
}
