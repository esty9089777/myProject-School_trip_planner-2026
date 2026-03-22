using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAttractionService
    {
        //attractions crud
        AttractionDto AddAttraction(AttractionDto attractionDto);
        void UpdateAttraction(int attractionId, AttractionDto attractionDto);
        void DeleteAttraction(int attractionId);
        AttractionDto GetAttractionById(int attractionId);

        //branch attractions crud
        BranchDto AddBranch(int attractionId, BranchDto branchDto);
        void UpdateBranch(int branchId, BranchDto branchDto);
        void DeleteBranch(int branchId);
        BranchDto GetBranchById(int branchId);
        List<BranchDto> GetBranchesByAttractionId(int attractionId);
    }
}
