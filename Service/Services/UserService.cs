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

        public Task<User> Add(User item)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(int id, User item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public UserDto Register(RegisterDto register)
        {
            throw new NotImplementedException();
        }
        public UserDto Login(LoginDto login)
        {
            throw new NotImplementedException();
        }
        public UserDto UpdateProfile(int userId, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
        public void ChangePassword(int userId, ChangePasswordDto changePasswordDto)
        {
            throw new NotImplementedException();
        }
        public void ResetPassword(string email)
        {
            throw new NotImplementedException();
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
    }
}
