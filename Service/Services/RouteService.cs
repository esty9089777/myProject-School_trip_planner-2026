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
    public class RouteService : IService<RouteDto>
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

        public async Task<RouteDto> Add(RouteDto item)
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

        public async Task Delete(int id)
        {
            var route = await _repository.GetById(id);
            if (route == null)
            {
                throw new Exception("Route not found");
            }
            await _repository.Delete(id);
        }

        public async Task<List<RouteDto>> GetAll()
        {
            var routes = await _repository.GetAll();
            return _mapper.Map<List<RouteDto>>(routes);
        }

        public async Task<RouteDto> GetById(int id)
        {
            var route = await _repository.GetById(id);
            if (route == null)
            {
                throw new Exception("Route not found");
            }
            return _mapper.Map<RouteDto>(route);
        }

        public async Task<RouteDto> Update(int id, RouteDto item)
        {
            var route = await _repository.GetById(id);
            if (route == null)
            {
                throw new KeyNotFoundException($"Route with id {id} not found.");
            }
            _mapper.Map(item, route);
            var updatedRoute = await _repository.Update(route.RouteId, route);
            return _mapper.Map<RouteDto>(updatedRoute);
        }
    }
}
