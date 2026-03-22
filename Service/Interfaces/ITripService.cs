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
        TripDto CreateTrip(TripDto tripDto);
        TripDto GetTripById(int tripId);
        List<TripDto> GetTripsByUserId(int userId);
    }
}
