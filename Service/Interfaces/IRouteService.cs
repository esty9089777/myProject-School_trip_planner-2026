using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRouteService:IService<Route>
    {
        Task AddRoute(RouteDto routeDto);
        Task UpdateRoute(int routeId, RouteDto routeDto);
        Task DeleteRoute(int routeId);
        Task<RouteDto> GetRouteById(int routeId);
    }
}
