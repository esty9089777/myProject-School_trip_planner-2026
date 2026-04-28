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
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;
        private readonly IService<Attraction> _attractionService;

        public BranchService(IBranchRepository repository, IMapper mapper, IService<Attraction> attractionService)
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

        public async Task<List<BranchDto>> GetBranchesByAttractionId(int AttractionId)
        {
            var branches = await _repository.GetAll();
            var filteredBranches = branches.Where(b => b.AttractionId == AttractionId).ToList();
            return _mapper.Map<List<BranchDto>>(filteredBranches);
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

        public async Task<List<BranchDto>> GetNearbyBranches(double lat, double lng)
        {
            var branches = await _repository.GetNearbyBranches(lat, lng);

            var sortedBranches = branches
                .OrderBy(b => Math.Pow(b.Latitude - lat, 2) + Math.Pow(b.Longitude - lng, 2))
                .Take(5) 
                .ToList();

            return _mapper.Map<List<BranchDto>>(sortedBranches);
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
