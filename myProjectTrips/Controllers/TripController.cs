using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myProject_trips.Extensions;
using Service.Interfaces;
using Service.Services;

namespace myProject_trips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ITripService _tripService;

        public TripController(ITripService tripService, IAuthorizationService authorizationService)
        {
            _tripService = tripService;
            _authorizationService = authorizationService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var trips = await _tripService.GetAll();
            return Ok(trips);
        }

        [Authorize]
        [HttpGet("my-trips")]
        public async Task<IActionResult> GetTripsById()
        {
            var currentUser = User.GetUserDetails();
            if (currentUser == null) return Unauthorized();

            var trips = await _tripService.GetTripsByUserId(currentUser.UserId);

            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trip = await _tripService.GetById(id);
            if (trip == null)
            {
                return NotFound($"טיול עם מזהה {id} לא נמצא.");
            }
            return Ok(trip);
        }

        [Authorize]
        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] TripRequestDto request)
        {
            var userDetails = User.GetUserDetails();
            var trip = await _tripService.GenerateSmartTrip(userDetails, request);
            return Ok(trip);
        }

        [HttpPut("{id}")]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TripDto tripDto)
        {
            if (id != tripDto.TripId)
            {
                return BadRequest("מזהה הטיול אינו תואם.");
            }

            var existingTrip = await _tripService.GetById(id);
            if (existingTrip == null) return NotFound("הטיול לעדכון לא נמצא.");

            var authResult = await _authorizationService.AuthorizeAsync(User, existingTrip, "EditPolicy");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            var updatedTrip = await _tripService.Update(id, tripDto);
            return Ok(updatedTrip);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _tripService.GetById(id);
            if (trip == null) return NotFound("הטיול למחיקה לא נמצא.");

            var authResult = await _authorizationService.AuthorizeAsync(User, trip, "EditPolicy");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            await _tripService.Delete(id);
            return NoContent();
        }
    }
}
