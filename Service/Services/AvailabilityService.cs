using Common.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        public Task<AvailabilityDto> GetAvailabilityByAttractionId(int attractionId)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityDto> GetAvailabilityByBranchId(int branchId)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityDto> GetAvailabilityByRouteId(int routeId)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityDto> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityDto> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time)
        {
            throw new NotImplementedException();
        }
    }
}
