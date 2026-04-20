using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICommentRepository:IRepository<Comment>
    {
        Task AddComment(int userId, int? branchId, int? routeId, string content);
        Task<Comment> GetCommentById(int commentId);
        Task<List<Comment>> GetCommentByBranchId(int branchId);
        Task<List<Comment>> GetCommentByRouteId(int routeId);
        Task<List<Comment>> GetCommentsByUserId(int userId);
        Task DeleteComment(int commentId);
        Task UpdateComment(int commentId, string content);

    }
}
