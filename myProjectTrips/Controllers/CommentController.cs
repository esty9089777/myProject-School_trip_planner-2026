using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myProject_trips.Extensions;
using Service.Interfaces;
using System.Security.Claims;

namespace myProject_trips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService, IAuthorizationService authorizationService)
        {
            _commentService = commentService;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comments = await _commentService.GetAll();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comment = await _commentService.GetById(id);
            if (comment == null)
            {
                return NotFound($"תגובה עם מזהה {id} לא נמצאה.");
            }
            return Ok(comment);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentDto commentDto)
        {
            if (id != commentDto.CommentId)
            {
                return BadRequest("מזהה התגובה אינו תואם.");
            }

            var existingComment = await _commentService.GetById(id);
            if (existingComment == null) return NotFound("התגובה לעדכון לא נמצאה.");

            var authResult = await _authorizationService.AuthorizeAsync(User, existingComment, "EditPolicy");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            var updated = await _commentService.Update(id, commentDto);
            return Ok(updated);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentService.GetById(id);
            if (comment == null) return NotFound("התגובה למחיקה לא נמצאה.");

            var authResult = await _authorizationService.AuthorizeAsync(User, comment, "EditPolicy");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            await _commentService.Delete(id);
            return NoContent();
        }

        [HttpGet("branch/{branchId}")]
        public async Task<ActionResult<List<CommentDto>>> GetByBranch(int branchId)
        {
            try
            {
                var comments = await _commentService.GetCommentByBranchId(branchId);
                if (comments == null || !comments.Any())
                {
                    return NotFound($"No comments found for branch {branchId}.");
                }
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("route/{routeId}")]
        public async Task<ActionResult<List<CommentDto>>> GetByRoute(int routeId)
        {
            try
            {
                var comments = await _commentService.GetCommentByRouteId(routeId);
                if (comments == null || !comments.Any())
                {
                    return NotFound($"No comments found for route {routeId}.");
                }
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
