using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService: IService<UserDto>
    {
        Task<UserDto> Register(RegisterDto registerDto);
        Task<UserDto> Login(LoginDto login);
        Task ChangePassword(int userId, ChangePasswordDto changePasswordDto);
        Task ResetPassword(string email);
        Task<TripDto> GetTrip(int userId, int tripId);
        Task<List<TripDto>> GetUserTrips(int userId);
    }
}
