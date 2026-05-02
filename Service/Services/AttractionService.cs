using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AttractionService : IService<AttractionDto>, IsExist<AttractionDto>
    {
        private readonly IRepository<Attraction> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Branch> _branchRepository;
        private readonly IUserService _userService;

        public AttractionService(IRepository<Attraction> repository, IMapper mapper, IRepository<Branch> branchRepository, IUserService userService)
        {
            _repository = repository;
            _mapper = mapper;
            _branchRepository = branchRepository;
            _userService = userService;
        }

        public async Task<List<AttractionDto>> GetAll()
        {
            var attractions = await _repository.GetAll();
            return _mapper.Map<List<AttractionDto>>(attractions);
        }

        public async Task<AttractionDto> GetById(int id)
        {
            var attraction = await _repository.GetById(id);
            return _mapper.Map<AttractionDto>(attraction);
        }

        public async Task<AttractionDto> Add(AttractionDto item)
        {
            var user = await _userService.GetById(item.CreatorId);
            if (user == null || user.Role == "User")
            {
                throw new UnauthorizedAccessException("Unauthorized to add attractions or branches");
            }
            var existingAttraction = await _repository.GetById(item.AttractionId);

            if (existingAttraction == null)
            {
                var entity = _mapper.Map<Attraction>(item);
                var addedEntity = await _repository.Add(entity);
                return _mapper.Map<AttractionDto>(addedEntity);
            }
            if (item.Branches != null && item.Branches.Any())
            {
                var branches = _mapper.Map<List<Branch>>(item.Branches);
                foreach (var branch in branches)
                {
                    branch.AttractionId = existingAttraction.AttractionId;
                    await _branchRepository.Add(branch);
                }
            }
            return _mapper.Map<AttractionDto>(existingAttraction);
        }

        public async Task<AttractionDto> Update(int id, AttractionDto item)
        {
            var attraction = await _repository.GetById(id);
            if (attraction == null)
            {
                throw new KeyNotFoundException($"Attraction with id {id} not found.");
            }
            _mapper.Map(item, attraction);
            var updatedAttraction = await _repository.Update(attraction.AttractionId, attraction);
            return _mapper.Map<AttractionDto>(updatedAttraction);
        }

        public async Task Delete(int id)
        {
            var a = await _repository.GetById(id);
            if (a == null)
            {
                throw new Exception("Attraction not found");
            }

            if (a.Branches != null)
            {
                foreach (var branch in a.Branches)
                {
                    await _branchRepository.Delete(branch.BranchId);
                }
            }
            await _repository.Delete(id);
        }

        public async Task<AttractionDto> Exist(AttractionDto attraction)
        {
            var list = await GetAll();
            return list.FirstOrDefault(a => a.AttractionId == attraction.AttractionId);
        }
    }
}
