using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAttractionRepository:IRepository<Attraction>
    {
        Task<Attraction> AddAttraction(Attraction attractionDto);
        Task UpdateAttraction(int attractionId, Attraction attractionDto);
        Task DeleteAttraction(int attractionId);
        Task<Attraction> GetAttractionById(int attractionId);
    }
}
