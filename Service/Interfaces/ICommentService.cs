using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICommentService:IService<Comment>
    {
        Task AddComment(int userId, int? branchId, int? routeId, string content);
        Task<CommentDto> GetCommentById(int commentId);
        Task<List<CommentDto>> GetCommentByBranchId(int branchId);
        Task<List<CommentDto>> GetCommentByRouteId(int routeId);
        Task<List<CommentDto>> GetCommentsByUserId(int userId);
        Task DeleteComment(int commentId);
        Task UpdateComment(int commentId, string content);
    }
}
