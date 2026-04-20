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
        private readonly IContext ctx;

        public AvailabilityRepository(IContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Availability> Add(Availability item)
        {
            await ctx.Availabilities.AddAsync(item);
            await ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var a = await ctx.Availabilities.FirstOrDefaultAsync(x => x.AvailabilityId == id);
            if (a == null)
            {
                throw new Exception("Availability not found");
            }
            ctx.Availabilities.Remove(a);
            await ctx.Save();
        }

        public async Task<List<Availability>> GetAll()
        {
            return await ctx.Availabilities.ToListAsync();
        }

        public async Task<Availability> GetAvailabilityByAttractionId(int attractionId)
        {
            return await ctx.Availabilities.FirstOrDefaultAsync(x => x.AttractionId == attractionId);
        }

        public async Task<Availability> GetAvailabilityByBranchId(int branchId)
        {
            return await ctx.Availabilities.FirstOrDefaultAsync(x => x.BranchId == branchId);
        }

        public async Task<Availability> GetAvailabilityByRouteId(int routeId)
        {
            return await ctx.Availabilities.FirstOrDefaultAsync(x => x.RouteId == routeId);
        }

        public Task<Availability> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> GetById(int id)
        {
            return ctx.Availabilities.FirstOrDefaultAsync(x => x.AvailabilityId == id);
        }

        public async Task<Availability> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time)
        {
            return await ctx.Availabilities
                    .FirstOrDefaultAsync(x => x.BranchId == branchId &&
                    x.Day == day &&
                    time >= x.OpenTime &&
                    time <= x.CloseTime);
        }

        public async Task<Availability> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time)
        {
            return await ctx.Availabilities
                    .FirstOrDefaultAsync(x => x.RouteId == routeId &&
                    x.Day == day &&
                    time >= x.OpenTime &&
                    time <= x.CloseTime);
        }

        public async Task<Availability> Update(int id, Availability item)
        {
            var a = await ctx.Availabilities.FirstOrDefaultAsync(x => x.AvailabilityId == id);
            if (a == null)
            {
                throw new Exception("Availability not found");
            }
            a.AvailabilityId = id;
            a.AttractionId = item.AttractionId;
            a.BranchId = item.BranchId;
            a.RouteId = item.RouteId;
            a.Attraction = item.Attraction;
            a.Branch = item.Branch;
            a.Route = item.Route;
            a.Day = item.Day;
            a.OpenTime = item.OpenTime;
            a.CloseTime = item.CloseTime;
            await ctx.Save();
            return a;
        }
    }
}
