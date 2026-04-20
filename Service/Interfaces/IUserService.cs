using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService: IService<User>
    {
        Task<UserDto> Login(LoginDto login);
        Task ChangePassword(int userId, ChangePasswordDto changePasswordDto);
        Task ResetPassword(string email);
        Task AddAttraction(int userId, AttractionDto branchDto);
        Task AddRoute(int userId, RouteDto routeDto);
        Task RemoveAttraction(int userId, int attractionId);
        Task RemoveRoute(int userId, int routeId);
        Task<TripDto> GetTrip(int userId, int tripId);
        Task<List<TripDto>> GetUserTrips(int userId);
    }
}
