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
        UserDto Register(RegisterDto register);
        UserDto Login(LoginDto login);
        UserDto UpdateProfile(int userId, UpdateUserDto updateUserDto);
        void ChangePassword(int userId, ChangePasswordDto changePasswordDto);
        void ResetPassword(string email);
        void AddAttraction(int userId, BranchDto branchDto);
        void AddRoute(int userId, RouteDto routeDto);
        void RemoveAtraction(int userId, int branchId);
        void RemoveRoute(int userId, int routeId);
        void DeleteUser(int userId);
        TripDto GetTrip(int userId, int tripId);
        List<TripDto> GetUserTrips(int userId);
    }
}
