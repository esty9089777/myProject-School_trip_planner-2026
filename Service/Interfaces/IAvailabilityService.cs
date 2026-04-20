using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAvailabilityService
    {
        Task<AvailabilityDto> GetAvailabilityByBranchId(int branchId);
        Task<AvailabilityDto> GetAvailabilityByAttractionId(int attractionId);
        Task<AvailabilityDto> GetAvailabilityByRouteId(int routeId);
        Task<AvailabilityDto> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time);
        Task<AvailabilityDto> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time);
    }
}
