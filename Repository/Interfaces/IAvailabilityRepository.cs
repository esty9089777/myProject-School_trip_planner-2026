using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAvailabilityRepository:IRepository<Availability>
    {
        Task<Availability> AddAvailability(Availability dto);
        Task UpdateAvailability(int id, Availability dto);
        Task DeleteAvailability(int id);
        Task<Availability> GetAvailabilityById(int id);
        Task<Availability> GetAvailabilityByBranchId(int branchId);
        Task<Availability> GetAvailabilityByAttractionId(int attractionId);
        Task<Availability> GetAvailabilityByRouteId(int routeId);
        Task<Availability> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time);
        Task<Availability> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time);

    }
}
