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
        Task<List<Comment>> GetCommentByBranchId(int branchId);
        Task<List<Comment>> GetCommentByRouteId(int routeId);
    }
}
