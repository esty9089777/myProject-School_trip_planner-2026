using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BranchService : IBranchService
    {
        private readonly IRepository<Branch> _repository;
        private readonly IMapper _mapper;

        public BranchService(IRepository<Branch> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public BranchDto AddBranch(BranchDto dto)
        {
            throw new NotImplementedException();
        }

        public BranchDto AddBranch(int AttractionId, BranchDto dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteBranch(int id)
        {
            throw new NotImplementedException();
        }

        public BranchDto FilterBranches(BranchFilterDto filter)
        {
            throw new NotImplementedException();
        }

        public BranchDto GetAllBranches()
        {
            throw new NotImplementedException();
        }

        public BranchDto GetBranchById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BranchDto> GetBranchesByAttractionId(int AttractionId)
        {
            throw new NotImplementedException();
        }

        public BranchDto GetNearbyBranches(double lat, double lng)
        {
            throw new NotImplementedException();
        }

        public void UpdateBranch(int id, BranchDto dto)
        {
            throw new NotImplementedException();
        }

        List<BranchDto> IBranchService.GetAllBranches()
        {
            throw new NotImplementedException();
        }
    }
}
