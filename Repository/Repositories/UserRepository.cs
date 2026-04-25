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
    public class UserRepository : IUserRepository
    {
        private readonly IContext _ctx;
        private readonly IMapper _mapper;
        public UserRepository(IContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<User> Add(User item)
        {
            await _ctx.Users.AddAsync(item);
            await _ctx.Save();
            return item;
        }

        public async Task AddAttraction(int userId, int attractionId)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.UserRole == UserRoleEnum.User)
            {
                throw new Exception("Only Business Owners and Admin can add attractions");
            }

            var attraction = await _ctx.Attractions.FirstOrDefaultAsync(a => a.AttractionId == attractionId);

            if (attraction == null)
            {
                throw new Exception("Attraction not found");
            }

            attraction.CreatorId = userId;

            await _ctx.Save();
        }

        public async Task AddRoute(int userId, int routeId)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.UserRole == UserRoleEnum.User)
            {
                throw new Exception("Only Business Owners and Admin can add attractions");
            }

            var route = await _ctx.Routes.FirstOrDefaultAsync(r => r.RouteId == routeId);

            if (route == null)
            {
                throw new Exception("Route not found");
            }

            route.CreatorId = userId;

            await _ctx.Save();
        }

        public Task ChangePassword(int userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var u = await _ctx.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (u == null)
            {
                throw new Exception("User not found");
            }
            _ctx.Users.Remove(u);
            await _ctx.Save();
        }

        public async Task<List<User>> GetAll()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.UserEmail == email);
        }

        public async Task<User> GetById(int id)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public Task<Trip> GetTrip(int userId, int tripId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Trip>> GetUserTrips(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(string email)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAttraction(int userId, int attractionId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRoute(int userId, int routeId)
        {
            throw new NotImplementedException();
        }

        public Task ResetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(int id, User item)
        {
            var existingUser = await _ctx.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            _mapper.Map(item, existingUser);
            await _ctx.Save();
            return existingUser;
        }
    }
}
