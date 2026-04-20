using Microsoft.EntityFrameworkCore;
using myProjectTrips.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        public Task<Availability> Add(Availability item)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> AddAvailability(Availability dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAvailability(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Availability>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Availability> GetAvailabilityByAttractionId(int attractionId)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> GetAvailabilityByBranchId(int branchId)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> GetAvailabilityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> GetAvailabilityByRouteId(int routeId)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> Update(int id, Availability item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAvailability(int id, Availability dto)
        {
            throw new NotImplementedException();
        }
    }
}
