using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAvailabilityService : IService<AvailabilityDto>
    {
        Task<List<AvailabilityDto>> GetAvailabilityByBranchId(int branchId);
        Task<List<AvailabilityDto>> GetAvailabilityByAttractionId(int attractionId);
        Task<List<AvailabilityDto>> GetAvailabilityByRouteId(int routeId);
        Task<AvailabilityDto> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time);
        Task<AvailabilityDto> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time);
    }
}
