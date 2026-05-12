using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRouteService : IService<RouteDto>
    {
        Task<List<RouteDto>> GetNearbyRoute(double lat, double lng);
        Task<bool> DeleteProtected(int routeId, int currentUserId, bool isAdmin);
        Task<RouteDto> UpdateProtected(int id, RouteDto route, int currentUserId, bool isAdmin);

    }
}
