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
    public class UserService : IUserService, IsExist<UserDto>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly ITripService _tripService;

        public UserService(IRepository<User> repository, IMapper mapper, ITripService tripService)
        {
            _repository = repository;
            _mapper = mapper;
            _tripService = tripService;
        }

        public async Task<UserDto> Add(UserDto item)
        {
            throw new NotImplementedException("Use Register method for new users");
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user = await _repository.GetByEmail(registerDto.UserEmail);
            if (user != null)
            {
                throw new Exception("User already exists");
            }
            var userEntity = _mapper.Map<User>(registerDto);
            var addedUser = await _repository.Add(userEntity);
            return _mapper.Map<UserDto>(addedUser);
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
            await _repository.Update(user.UserId, user);
        }

        public async Task Delete(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            await _repository.Delete(id);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _repository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found");
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<TripDto> GetTrip(int userId, int tripId)
        {
            var user = await _repository.GetById(userId);
            if (user == null)
            {
                throw new Exception($"User with id {userId} not found");
            }

            var trip = await _tripService.GetById(tripId);
            if (trip == null || trip.UserEmail != user.UserEmail)
            {
                throw new Exception($"Trip with id {tripId} not found for user with id {userId}");
            }

            return trip;
        }

        public async Task<List<TripDto>> GetUserTrips(int userId)
        {
            var user = await _repository.GetById(userId);
            if (user == null)
            {
                throw new Exception($"User with id {userId} not found");
            }

            var allTrips = await _tripService.GetAll();

            var filteredTrips = allTrips.Where(t => t.UserEmail == user.UserEmail).ToList();

            return filteredTrips;
        }

        public async Task<UserDto> Login(LoginDto login)
        {
            var user = await _repository.GetByEmail(login.Email);
            if (user == null)
                throw new Exception("User not found");

            if (user.UserPassword != login.Password)
                throw new Exception("Wrong password");

            return _mapper.Map<UserDto>(user);
        }

        public async Task ResetPassword(string email)
        {
            var user = await _repository.GetByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.UserPassword = "AB123#c63*";
            await _repository.Update(user.UserId, user);
        }

        public async Task<UserDto> Update(int id, UserDto item)
        {
            var existingUser = await _repository.GetById(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            _mapper.Map(item, existingUser);
            existingUser.UserId = id; 
            var updatedUser = await _repository.Update(id, existingUser);
            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task<UserDto> Exist(LoginDto user)
        {
            var list = await GetAll();
            return list.FirstOrDefault(a => a.UserEmail == user.Email);
        }
    }
}
