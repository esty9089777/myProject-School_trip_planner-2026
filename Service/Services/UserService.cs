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
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        //public async Task AddAttraction(UserDto userDto, AttractionDto dto)
        //{
        //    if (userDto == null)
        //    {
        //        throw new Exception("User not found");
        //    }
        //    var attraction = _mapper.Map<Attraction>(dto);
        //    var existingAttraction = await _repository.GetAttractionById(attraction.AttractionId);
        //    var user = _mapper.Map<User>(userDto);

        //    if (existingAttraction == null)
        //    {
        //        await _repository.AddAttraction(attraction, user);
        //    }
        //    var branch = new Branch
        //    {
        //        BranchName = attraction.AttraName,

        //    };
        //    await _repository.AddBranch(branch);
        //}
        //public void AddRoute(int userId, RouteDto routeDto)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task RemoveAttraction(int userId, int attractionId)
        //{
        //    Attraction attraction = await _repository.GetAttractionById(attractionId);

        //    if (attraction == null)
        //    {
        //        throw new Exception("Attraction not found");
        //    }
        //    if (userId != attraction.CreatorId)
        //    {
        //        throw new Exception("User is not the creator of the attraction");
        //    }
        //    await _repository.RemoveAttraction(attraction, userId);
        //}

        public async Task<UserDto> Add(UserDto item)
        {
            var user = await _repository.GetByEmail(item.UserEmail);
            if (user != null)
            {
                throw new Exception("User already exists");
            }
            var userEntity = _mapper.Map<User>(item);
            var addedUser = await _repository.Add(userEntity);

            return _mapper.Map<UserDto>(addedUser);
        }

        public Task AddAttraction(int userId, AttractionDto branchDto)
        {
            throw new NotImplementedException();
        }

        public Task AddRoute(int userId, RouteDto routeDto)
        {
            throw new NotImplementedException();
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

        public Task<TripDto> GetTrip(int userId, int tripId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TripDto>> GetUserTrips(int userId)
        {
            throw new NotImplementedException();
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

        public Task RemoveAttraction(int userId, int attractionId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRoute(int userId, int routeId)
        {
            throw new NotImplementedException();
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
            var userToUpdate = _mapper.Map<User>(item);
            userToUpdate.UserId = id; 
            var updatedUser = await _repository.Update(id, userToUpdate);
            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}
