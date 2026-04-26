using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITripService:IService<Trip>
    {
        Task<List<TripDto>> GetTripsByUserId(int userId);
    }
}
