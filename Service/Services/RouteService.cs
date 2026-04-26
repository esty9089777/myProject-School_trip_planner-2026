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
    public class RouteService : IService<Route>
    {
        private readonly IRepository<Route> _repository;
        private readonly IMapper _mapper;

        public RouteService(IRepository<Route> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Route> Add(Route item)
        {
            throw new NotImplementedException();
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
