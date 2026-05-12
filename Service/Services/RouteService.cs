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
    public class RouteService : IRouteService, IsExist<RouteDto>
    {
        private readonly IRouteRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RouteService(IRouteRepository repository, IMapper mapper, IUserService userService)
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
                throw new KeyNotFoundException("Route not found");
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

        public async Task<RouteDto> Exist(RouteDto route)
        {
            var list = await GetAll();
            return list.FirstOrDefault(a => a.RouteId == route.RouteId);
        }

        public async Task<List<RouteDto>> GetNearbyRoute(double lat, double lng)
        {
            var routes = await _repository.GetNearbyRoute(lat, lng);

            var sortedRoutes = routes
                .OrderBy(r => Math.Pow(r.Latitude - lat, 2) + Math.Pow(r.Longitude - lng, 2))
                .Take(5)
                .ToList();

            return _mapper.Map<List<RouteDto>>(sortedRoutes);
        }

        public async Task<bool> DeleteProtected(int routeId, int currentUserId, bool isAdmin)
        {
            var route = await _repository.GetById(routeId);

            if (route == null)
                throw new KeyNotFoundException("המסלול לא נמצא");

            bool isOwner = false;

            if (route != null)
            {
                isOwner = route.CreatorId == currentUserId;
            }

            if (isOwner || isAdmin)
            {
                await _repository.Delete(routeId);
                return true;
            }
            else
            {
                throw new UnauthorizedAccessException("אין לך הרשאה למחוק מסלול זה");
            }
        }

        public async Task<RouteDto> UpdateProtected(int id, RouteDto route, int currentUserId, bool isAdmin)
        {
            var existingRoute = await _repository.GetById(id);

            if (existingRoute == null)
                throw new KeyNotFoundException("המסלול לא נמצא");

            bool isOwner = existingRoute.CreatorId == currentUserId;

            if (isOwner || isAdmin)
            {
                _mapper.Map(route, existingRoute);
                var updatedEntity = await _repository.Update(id, existingRoute);
                return _mapper.Map<RouteDto>(updatedEntity);
            }
            else
            {
                throw new UnauthorizedAccessException("אין לך הרשאה לעדכן מסלול זה");
            }
        }

        public Task<RouteDto> Exist(LoginDto l)
        {
            throw new NotImplementedException();
        }
    }
}
