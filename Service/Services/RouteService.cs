using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RouteService : IService<Route>
    {
        private readonly IRepository<Route> _repository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RouteService(IRepository<Route> repository, IMapper mapper, IUserService userService)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<RouteDto> Add(Route item)
        {
            var user = await _userService.GetById(item.CreatorId);
            if (user == null)
            { 
                throw new Exception("User not found");
            }

            if (user.Role == "User")
            {
                throw new Exception("Only Business Owners and Admin can add routes");
            }

            var routeEntity = _mapper.Map<Route>(item);
            var addedRoute = await _repository.Add(routeEntity);

            return _mapper.Map<RouteDto>(addedRoute);
        }

        public void AddRoute(RouteDto routeDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoute(int routeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Route>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Route> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RouteDto GetRouteById(int routeId)
        {
            throw new NotImplementedException();
        }

        public Task<Route> Update(int id, Route item)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoute(int routeId, RouteDto routeDto)
        {
            throw new NotImplementedException();
        }
    }
}
