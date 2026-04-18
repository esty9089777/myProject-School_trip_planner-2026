using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetAll()
        {
            var user = await _repository.GetAll();
            var userDtos = _mapper.Map<List<UserDto>>(user);
            return userDtos;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _repository.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> Add(UserDto item)
        {
            var userEntity = _mapper.Map<User>(item);
            var addedUser = await _repository.Add(userEntity);
            return _mapper.Map<UserDto>(addedUser);
        }

        public async Task<UserDto> Update(int id, UserDto item)
        {
            var userEntity = _mapper.Map<User>(item);
            var updatedUser = await _repository.Update(id, userEntity);
            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<UserDto> Register(RegisterDto register)
        {
            var user = await _repository.GetByUsername(register.UserName);
            if (user != null)
            {
                throw new Exception("User already exists");
            }
            var userEntity = _mapper.Map<User>(register);
            var addedUser = await _repository.Add(userEntity);

            return _mapper.Map<UserDto>(addedUser);
        }

        public async UserDto Login(LoginDto login)
        {
            var user = await _repository.GetByUsername(login.Email);
            if (user == null)
                throw new Exception("User not found");

            if (user.Password != login.Password)
                throw new Exception("Wrong password");

            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> UpdateProfile(int userId, UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<User>(updateUserDto);
            user.UserId = userId;
            return await _repository.Update(user);
        }
        public async Task ChangePassword(int userId, ChangePasswordDto changePasswordDto)
        {
            var user = await _repository.GetById(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (changePasswordDto.CurrentPassword != user.UserPassword)
            {
                throw new Exception("Current password is incorrect");
            }
            if (changePasswordDto.CurrentPassword == changePasswordDto.NewPassword)
            {
                throw new Exception("New password cannot be the same as the current password");
            }
            if (changePasswordDto.NewPassword != changePasswordDto.ConfirmNewPassword)
            {
                throw new Exception("New password and confirmation do not match");
            }
            user.UserPassword = changePasswordDto.NewPassword;
            await _repository.Update(user);
        }
        public async Task ResetPassword(ResetPasswordDto dto)
        {
            var user = await _repository.GetByEmail(dto.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (dto.NewPassword != dto.ConfirmNewPassword)
            {
                throw new Exception("New password and confirmation do not match");
            }
            user.UserPassword = dto.NewPassword;
            await _repository.Update(user);
        }
        public void AddAttraction(int userId, BranchDto branchDto)
        {
            throw new NotImplementedException();
        }
        public void AddRoute(int userId, RouteDto routeDto)
        {
            throw new NotImplementedException();
        }
        public void RemoveAtraction(int userId, int branchId)
        {
            throw new NotImplementedException();
        }
        public void RemoveRoute(int userId, int routeId)
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
        public TripDto GetTrip(int userId, int tripId)
        {
            throw new NotImplementedException();
        }
        public List<TripDto> GetUserTrips(int userId)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IService<User>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<User> IService<User>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
