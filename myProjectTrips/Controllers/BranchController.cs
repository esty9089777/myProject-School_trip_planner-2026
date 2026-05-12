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
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var branches = await _branchService.GetAll();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var branch = await _branchService.GetById(id);
            if (branch == null)
            {
                return NotFound($"סניף עם מזהה {id} לא נמצא.");
            }
            return Ok(branch);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BranchDto branch)
        {
            var userDetails = User.GetUserDetails();
            if (userDetails == null) return Unauthorized();

            try
            {
                var result = await _branchService.UpdateProtected(
                    id,
                    branch,
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
                var success = await _branchService.DeleteProtected(
                    id,
                    userDetails.UserId,
                    User.IsInRole("Admin")
                );

                if (!success) return NotFound("הסניף למחיקה לא נמצא");
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
        }

        [HttpGet("attraction/{attractionId}")]
        public async Task<ActionResult<List<BranchDto>>> GetByAttractionId(int attractionId)
        {
            var branches = await _branchService.GetBranchesByAttractionId(attractionId);

            if (branches == null || !branches.Any())
            {
                return NotFound($"לא נמצאו סניפים עבור אטרקציה שמספרה {attractionId}");
            }

            return Ok(branches);
        }

        [HttpGet("nearby")]
        public async Task<ActionResult<List<BranchDto>>> GetNearby([FromQuery] double lat, [FromQuery] double lng)
        {
            var branches = await _branchService.GetNearbyBranches(lat, lng);

            if (branches == null || !branches.Any())
            {
                return Ok(new List<BranchDto>());
            }

            return Ok(branches);
        }
    }
}
