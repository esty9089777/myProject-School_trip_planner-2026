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
        Task<List<Branch>> GetBranchesByAttractionId(int AttractionId);
        Task<Branch> GetNearbyBranches(double lat, double lng);

    }
}
