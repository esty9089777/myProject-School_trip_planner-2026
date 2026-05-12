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
    public class AttractionController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IService<AttractionDto> _attractionService;

        public AttractionController(IService<AttractionDto> attractionService, IAuthorizationService authorizationService)
        {
            _attractionService = attractionService;
            _authorizationService = authorizationService;
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
            var existingAttraction = await _attractionService.GetById(id);
            if (existingAttraction == null) return NotFound();

            var authResult = await _authorizationService.AuthorizeAsync(User, existingAttraction, "EditPolicy");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            var result = await _attractionService.Update(id, attraction);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var attraction = await _attractionService.GetById(id);
            if (attraction == null) return NotFound();

            var authResult = await _authorizationService.AuthorizeAsync(User, attraction, "EditPolicy");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            await _attractionService.Delete(id);
            return NoContent();
        }
    }
}
