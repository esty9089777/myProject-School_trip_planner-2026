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
        void AddRoute(RouteDto routeDto);
        void UpdateRoute(int routeId, RouteDto routeDto);
        void DeleteRoute(int routeId);
        RouteDto GetRouteById(int routeId);
    }
}
