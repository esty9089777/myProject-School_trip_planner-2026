using AutoMapper;
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
        private readonly IContext _ctx;
        private readonly IMapper _mapper;

        public AvailabilityRepository(IContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<Availability> Add(Availability item)
        {
            await _ctx.Availabilities.AddAsync(item);
            await _ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var a = await _ctx.Availabilities.FirstOrDefaultAsync(x => x.AvailabilityId == id);
            if (a == null)
            {
                throw new Exception("Availability not found");
            }
            _ctx.Availabilities.Remove(a);
            await _ctx.Save();
        }

        public async Task<List<Availability>> GetAll()
        {
            return await _ctx.Availabilities.ToListAsync();
        }

        public async Task<Availability> GetAvailabilityByAttractionId(int attractionId)
        {
            return await _ctx.Availabilities.FirstOrDefaultAsync(x => x.AttractionId == attractionId);
        }

        public async Task<Availability> GetAvailabilityByBranchId(int branchId)
        {
            return await _ctx.Availabilities.FirstOrDefaultAsync(x => x.BranchId == branchId);
        }

        public async Task<Availability> GetAvailabilityByRouteId(int routeId)
        {
            return await _ctx.Availabilities.FirstOrDefaultAsync(x => x.RouteId == routeId);
        }

        public Task<Availability> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> GetById(int id)
        {
            return _ctx.Availabilities.FirstOrDefaultAsync(x => x.AvailabilityId == id);
        }

        public async Task<Availability> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time)
        {
            return await _ctx.Availabilities
                    .FirstOrDefaultAsync(x => x.BranchId == branchId &&
                    x.Day == day &&
                    time >= x.OpenTime &&
                    time <= x.CloseTime);
        }

        public async Task<Availability> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time)
        {
            return await _ctx.Availabilities
                    .FirstOrDefaultAsync(x => x.RouteId == routeId &&
                    x.Day == day &&
                    time >= x.OpenTime &&
                    time <= x.CloseTime);
        }

        public async Task<Availability> Update(int id, Availability item)
        {
            var existingAvailability = await _ctx.Availabilities.FirstOrDefaultAsync(a => a.AvailabilityId == id);
            if (existingAvailability == null)
            {
                throw new Exception("Availability not found");
            }

            _mapper.Map(item, existingAvailability);
            await _ctx.Save();
            return existingAvailability;
        }
    }
}
