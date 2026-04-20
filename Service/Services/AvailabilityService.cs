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
        public AvailabilityDto AddAvailability(AvailabilityDto dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteAvailability(int id)
        {
            throw new NotImplementedException();
        }

        public AvailabilityDto GetAvailabilityByAttractionId(int attractionId)
        {
            throw new NotImplementedException();
        }

        public AvailabilityDto GetAvailabilityByBranchId(int branchId)
        {
            throw new NotImplementedException();
        }

        public AvailabilityDto GetAvailabilityById(int id)
        {
            throw new NotImplementedException();
        }

        public AvailabilityDto GetAvailabilityByRouteId(int routeId)
        {
            throw new NotImplementedException();
        }

        public AvailabilityDto IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time)
        {
            throw new NotImplementedException();
        }

        public AvailabilityDto IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time)
        {
            throw new NotImplementedException();
        }

        public void UpdateAvailability(int id, AvailabilityDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
