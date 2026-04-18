using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBranchService
    {
        BranchDto GetAllBranches();
        BranchDto GetBranchById(int id);
        BranchDto AddBranch(BranchDto dto);
        void UpdateBranch(int id, BranchDto dto);
        void DeleteBranch(int id);
        BranchDto FilterBranches(BranchFilterDto filter);
        BranchDto GetNearbyBranches(double lat, double lng);
    }
}
