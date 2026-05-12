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
    public class AttractionController : ControllerBase
    {
        private readonly IService<AttractionDto> _attractionService;

        public AttractionController(IService<AttractionDto> attractionService)
        {
            _attractionService = attractionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var attractions = await _attractionService.GetAll();
            return Ok(attractions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var attraction = await _attractionService.GetById(id);
            if (attraction == null)
            {
                return NotFound($"אטרקציה עם מזהה {id} לא נמצאה.");
            }
            return Ok(attraction);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AttractionDto attraction)
        {
            var userDetails = User.GetUserDetails();
            if (userDetails == null) return Unauthorized();

            try
            {
                var result = await _attractionService.UpdateProtected(
                    id,
                    attraction,
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
                var success = await _attractionService.DeleteProtected(
                    id,
                    userDetails.UserId,
                    User.IsInRole("Admin")
                );

                if (!success) return NotFound("האטרקציה למחיקה לא נמצאה");
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
        }

        [HttpGet("attraction/{attractionId}")]
    }
}
