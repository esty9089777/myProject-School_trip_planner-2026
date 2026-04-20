using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBranchRepository:IRepository<Branch>
    {
        Task<List<Branch>> GetAllBranches();
        Task<Branch> GetBranchById(int id);
        Task<List<Branch>> GetBranchesByAttractionId(int AttractionId);
        Task<Branch> AddBranch(int AttractionId, Branch branch);
        Task UpdateBranch(int id, Branch branch);
        Task DeleteBranch(int id);
        Task<Branch> GetNearbyBranches(double lat, double lng);

    }
}
