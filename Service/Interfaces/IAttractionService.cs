using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAttractionService:IService<Attraction>
    {
        AttractionDto AddAttraction(AttractionDto attractionDto);
        Task UpdateAttraction(int attractionId, AttractionDto attractionDto);
        Task DeleteAttraction(int attractionId);
        AttractionDto GetAttractionById(int attractionId);
    }
}
