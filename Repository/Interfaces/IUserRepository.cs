using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string email);
        Task ChangePassword(int userId, string newPassword);
        Task ResetPassword(string email);
        Task<Trip> GetTrip(int userId, int tripId);
        Task<List<Trip>> GetUserTrips(int userId);
    }
}
