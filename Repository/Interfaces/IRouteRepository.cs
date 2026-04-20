using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRouteRepository:IRepository<Route>
    {
        Task AddRoute(Route routeDto);
        Task UpdateRoute(int routeId, Route routeDto);
        Task DeleteRoute(int routeId);
        Task<Route> GetRouteById(int routeId);
    }
}
