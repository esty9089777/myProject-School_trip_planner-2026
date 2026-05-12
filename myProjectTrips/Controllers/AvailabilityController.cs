using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myProject_trips.Extensions;
using Service.Interfaces;

namespace myProject_trips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService _availabilityService;

        public AvailabilityController(IAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var availabilities = await _availabilityService.GetAll();
            return Ok(availabilities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var availability = await _availabilityService.GetById(id);
            if (availability == null)
            {
                return NotFound($"זמינות עם מזהה {id} לא נמצאה.");
            }
            return Ok(availability);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AvailabilityDto availability)
        {
            var userDetails = User.GetUserDetails();
            if (userDetails == null) return Unauthorized();

            try
            {
                var result = await _availabilityService.UpdateProtected(
                    id,
                    availability,
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
                var success = await _availabilityService.DeleteProtected(
                    id,
                    userDetails.UserId,
                    User.IsInRole("Admin")
                );

                if (!success) return NotFound("הזמינות למחיקה לא נמצאה");
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
        }

        [HttpGet("branch/{branchId}")]
        public async Task<IActionResult> GetByBranch(int branchId)
        {
            var availability = await _availabilityService.GetAvailabilityByBranchId(branchId);
            if (availability == null || !availability.Any()) 
                return NotFound("לא נמצאה זמינות לסניף זה");
            return Ok(availability);
        }

        [HttpGet("attraction/{attractionId}")]
        public async Task<IActionResult> GetByAttraction(int attractionId)
        {
            var availability = await _availabilityService.GetAvailabilityByAttractionId(attractionId);
            if (availability == null || !availability.Any()) return NotFound("לא נמצאה זמינות לאטרקציה זו.");
            return Ok(availability);
        }

        [HttpGet("branch/{branchId}/is-available")]
        public async Task<IActionResult> CheckBranchAvailability(int branchId, [FromQuery] DayOfWeek day, [FromQuery] TimeOnly time)
        {
            var result = await _availabilityService.IsBranchAvailable(branchId, day, time);
            if (result == null) return Ok(new { available = false }); // או להחזיר אובייקט ריק לפי הלוגיקה שלך
            return Ok(result);
        }

        [HttpGet("route/{routeId}/is-available")]
        public async Task<IActionResult> CheckRouteAvailability(int routeId, [FromQuery] DayOfWeek day, [FromQuery] TimeOnly time)
        {
            var result = await _availabilityService.IsRouteAvailable(routeId, day, time);
            if (result == null) return Ok(new { available = false });
            return Ok(result);
        }
    }
}
