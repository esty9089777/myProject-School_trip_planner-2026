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
    public class RouteRepository : IRepository<Route>
    {
        private readonly IContext _ctx;
        private readonly IMapper _mapper;
        public RouteRepository(IContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<Route> Add(Route item)
        {
            await _ctx.Routes.AddAsync(item);
            await _ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var r = await _ctx.Routes.FirstOrDefaultAsync(x => x.RouteId == id);
            if (r == null)
            {
                throw new Exception("Route not found");
            }
            _ctx.Routes.Remove(r);
            await _ctx.Save();
        }

        public async Task<List<Route>> GetAll()
        {
            return await _ctx.Routes.ToListAsync();
        }

        public async Task<Route> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Route> GetById(int id)
        {
            return await _ctx.Routes.FirstOrDefaultAsync(x => x.RouteId == id);
        }

        public async Task<Route> Update(int id, Route item)
        {
            var existingRoute = await _ctx.Routes.FirstOrDefaultAsync(a => a.RouteId == id);
            if (existingRoute == null)
            {
                throw new Exception("Route not found");
            }

            _mapper.Map(item, existingRoute);
            await _ctx.Save();
            return existingRoute;
        }
    }
}
