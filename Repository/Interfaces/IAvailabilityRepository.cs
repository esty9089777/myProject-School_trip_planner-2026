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
        Task<List<Availability>> GetAvailabilityByBranchId(int branchId);
        Task<List<Availability>> GetAvailabilityByAttractionId(int attractionId);
        Task<List<Availability>> GetAvailabilityByRouteId(int routeId);
        Task<Availability> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time);
        Task<Availability> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time);

    }
}
