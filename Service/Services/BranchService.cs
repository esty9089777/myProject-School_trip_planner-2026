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
        private readonly IService<Attraction> _attractionService;

        public BranchService(IRepository<Branch> repository, IMapper mapper, IService<Attraction> attractionService)
        {
            _repository = repository;
            _mapper = mapper;
            _attractionService = attractionService;
        }

        public async Task<BranchDto> Add(BranchDto item)
        {
            var attraction = await _attractionService.GetById(item.AttractionId);
            if (attraction == null)
            {
                throw new Exception("Attraction not found");
            }
            var branch = _mapper.Map<Branch>(item);
            var addedBranch = await _repository.Add(branch);

            return _mapper.Map<BranchDto>(addedBranch);
        }

        public async Task Delete(int id)
        {
            var branch = await _repository.GetById(id);
            if (branch == null)
            {
                throw new Exception("Branch not found");
            }
            await _repository.Delete(id);
        }

        public async Task<List<BranchDto>> GetAll()
        {
            var branches = await _repository.GetAll();
            return _mapper.Map<List<BranchDto>>(branches);
        }

        public Task<List<BranchDto>> GetBranchesByAttractionId(int AttractionId)
        {
            throw new NotImplementedException();
        }

        public async Task<BranchDto> GetById(int id)
        {
            var branch = await _repository.GetById(id);
            if (branch == null)
            {
                throw new Exception("Branch not found");
            }
            return _mapper.Map<BranchDto>(branch);
        }

        public Task<BranchDto> GetNearbyBranches(double lat, double lng)
        {
            throw new NotImplementedException();
        }

        public async Task<BranchDto> Update(int id, BranchDto item)
        {
            var branch = await _repository.GetById(id);
            if (branch == null)
            {
                throw new Exception("Branch not found");
            }
            _mapper.Map(item, branch);
            var updatedBranch = await _repository.Update(branch.BranchId, branch);
            return _mapper.Map<BranchDto>(updatedBranch);
        }
    }
}
