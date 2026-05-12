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
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
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
        public async Task<IActionResult> Put(int id, [FromBody] RouteDto route)
        {
            var userDetails = User.GetUserDetails();
            if (userDetails == null) return Unauthorized();

            try
            {
                var result = await _routeService.UpdateProtected(
                    id,
                    route,
                    userDetails.UserId,
                    User.IsInRole("Admin")
                );

                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userDetails = User.GetUserDetails();
            if (userDetails == null) return Unauthorized();

            try
            {
                var success = await _routeService.DeleteProtected(
                    id,
                    userDetails.UserId,
                    User.IsInRole("Admin")
                );

                if (!success) return NotFound("המסלול למחיקה לא נמצא");
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
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
