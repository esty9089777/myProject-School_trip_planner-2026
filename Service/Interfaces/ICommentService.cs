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
        void AddComment(int userId, int? branchId, int? routeId, string content);
        CommentDto GetCommentById(int commentId);
        List<CommentDto> GetCommentByBranchId(int branchId);
        List<CommentDto> GetCommentByRouteId(int routeId);
        List<CommentDto> GetCommentsByUserId(int userId);
        void DeleteComment(int commentId);
        void UpdateComment(int commentId, string content);
    }
}
