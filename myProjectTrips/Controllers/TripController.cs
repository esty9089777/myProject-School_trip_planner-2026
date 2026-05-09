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
        private readonly ITripService _tripService;
        private readonly IsExist<TripDto> _isExist;
        private IConfiguration _configuration;
        private readonly TokenService _tokenService;

        public TripController(ITripService tripService, IsExist<TripDto> isExist, IConfiguration configuration, TokenService tokenService)
        {
            _tripService = tripService;
            _isExist = isExist;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<List<TripDto>> Get()
        {
            return await _tripService.GetAll();
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
        public async Task<TripDto> Get(int id)
        {
            return await _tripService.GetById(id);
        }

        [Authorize]
        [HttpPost("generate")]
        public async Task<ActionResult<TripDto>> Generate([FromBody] TripRequestDto request)
        {
            var userDetails = User.GetUserDetails();
            var trip = await _tripService.CreatePersonalizedTrip(userDetails, request);
            return Ok(trip);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TripDto>> Put(int id, [FromBody] TripDto trip)
        {
            if (id != trip.TripId)
            {
                return BadRequest("The trip ID does not match");
            }
            var result = await _tripService.Update(id, trip);
            if (result == null)
            {
                return NotFound("Trip not found");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTrip = await _tripService.GetById(id);
            if (existingTrip == null)
            {
                return NotFound($"טיול עם מזהה {id} לא נמצא במערכת.");
            }

            await _tripService.Delete(id);
            return NoContent();
        }
    }
}
