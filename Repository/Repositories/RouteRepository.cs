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
    public class RouteRepository : IRepository<Route>
    {
        private readonly IContext ctx;
        public RouteRepository(IContext context)
        {
            ctx = context;
        }

        public async Task<Route> Add(Route item)
        {
            await ctx.Routes.AddAsync(item);
            await ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var r = ctx.Routes.FirstOrDefault(x => x.RouteId == id);
            if (r == null)
            {
                throw new Exception("Route not found");
            }
            ctx.Routes.Remove(r);
            await ctx.Save();
        }

        public async Task<List<Route>> GetAll()
        {
            return await ctx.Routes.ToListAsync();
        }

        public async Task<Route> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Route> GetById(int id)
        {
            return await ctx.Routes.FirstOrDefaultAsync(x => x.RouteId == id);
        }

        public async Task<Route> Update(int id, Route item)
        {
            var r = await ctx.Routes.FirstOrDefaultAsync(x => x.RouteId == id);
            if (r == null)
            {
                throw new Exception("Route not found");
            }
            r.direction = item.direction;
            r.Description = item.Description;
            r.Duration = item.Duration;
            r.ImageUrl = item.ImageUrl;
            r.IsFree = item.IsFree;
            r.IsWet = item.IsWet;
            r.Latitude = item.Latitude;
            r.Longitude = item.Longitude;
            r.Points = item.Points;
            r.routeCategory = item.routeCategory;
            r.RouteName = item.RouteName;
            r.AgeGroup = item.AgeGroup;
            r.CreatorId = item.CreatorId;
            r.Creator = item.Creator;
            await ctx.Save();
            return r;
        }
    }
}
