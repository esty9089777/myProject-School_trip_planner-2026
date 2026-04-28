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

        public async Task ChangePassword(int userId, string newPassword)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.UserPassword = newPassword;
            await _ctx.Save();
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

        public async Task<Trip> GetTrip(int userId, int tripId)
        {
            return await _ctx.Trips.FirstOrDefaultAsync(t => t.TripId == tripId && t.UserId == userId);
        }

        public async Task<List<Trip>> GetUserTrips(int userId)
        {
            return await _ctx.Trips.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<User> Login(string email)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
        }

        public async Task ResetPassword(string email)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.UserPassword = "ab12#$%BO794*31A";
            await _ctx.Save();
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
