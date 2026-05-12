using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myProject_trips.Extensions;
using Service.Interfaces;

namespace myProject_trips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService, IAuthorizationService authorizationService)
        {
            _routeService = routeService;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var routes = await _routeService.GetAll();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var route = await _routeService.GetById(id);
            if (route == null)
            {
                return NotFound($"מסלול עם מזהה {id} לא נמצא.");
            }
            return Ok(route);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RouteDto routeDto)
        {
            var existingRoute = await _routeService.GetById(id);
            if (existingRoute == null) return NotFound();

            var authResult = await _authorizationService.AuthorizeAsync(User, existingRoute, "EditPolicy");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            var result = await _routeService.Update(id, routeDto);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var route = await _routeService.GetById(id);
            if (route == null) return NotFound();

            var authResult = await _authorizationService.AuthorizeAsync(User, route, "EditPolicy");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            await _routeService.Delete(id);
            return NoContent();
        }

        [HttpGet("nearby")]
        public async Task<ActionResult<List<RouteDto>>> GetNearby([FromQuery] double lat, [FromQuery] double lng)
        {
            var routes = await _routeService.GetNearbyRoute(lat, lng);

            if (routes == null || !routes.Any())
            {
                return Ok(new List<RouteDto>());
            }

            return Ok(routes);
        }

    }
}
