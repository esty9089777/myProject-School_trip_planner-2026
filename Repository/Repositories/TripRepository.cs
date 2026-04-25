using Microsoft.EntityFrameworkCore;
using myProjectTrips.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly IContext _ctx;
        private readonly IMapper _mapper;
        public TripRepository(IContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<Trip> Add(Trip item)
        {
            await _ctx.Trips.AddAsync(item);
            await _ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var t = await _ctx.Trips.FirstOrDefaultAsync(x => x.TripId == id);
            if (t == null)
            {
                throw new Exception("Trip not found");
            }
            _ctx.Trips.Remove(t);
            await _ctx.Save();

        }

        public async Task<List<Trip>> GetAll()
        {
            return await _ctx.Trips.ToListAsync();
        }

        public Task<Trip> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Trip> GetById(int id)
        {
            return await _ctx.Trips.FirstOrDefaultAsync(x => x.TripId == id);
        }

        public async Task<List<Trip>> GetTripsByUserId(int userId)
        {
            return await _ctx.Trips.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Trip> Update(int id, Trip item)
        {
            var existingTrip = await _ctx.Trips.FirstOrDefaultAsync(x => x.TripId == id);

            if (existingTrip == null)
            {
                throw new Exception("Trip not found");
            }
            _mapper.Map(item, existingTrip);

            await _ctx.Save();
            return existingTrip;
        }
    }
}
