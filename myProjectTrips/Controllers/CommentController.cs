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
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentDto comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest("מזהה התגובה אינו תואם.");
            }

            var updatedComment = await _commentService.Update(id, comment);
            if (updatedComment == null)
            {
                return NotFound("התגובה לעדכון לא נמצאה.");
            }

            return Ok(updatedComment);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            bool isAdmin = User.IsInRole("Admin");

            try
            {
                await _commentService.DeleteProtected(id, currentUserId, isAdmin);
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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
