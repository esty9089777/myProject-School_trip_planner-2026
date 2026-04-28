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
    public class AttractionService : IService<AttractionDto>
    {
        private readonly IRepository<Attraction> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Branch> _branchRepository;

        public AttractionService(IRepository<Attraction> repository, IMapper mapper, IRepository<Branch> branchRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _branchRepository = branchRepository;
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
            var existingAttraction = await _repository.GetById(item.AttractionId);

            if (existingAttraction == null)
            {
                var entity = _mapper.Map<Attraction>(item);
                var addedEntity = await _repository.Add(entity);
                return _mapper.Map<AttractionDto>(addedEntity);
            }
            else
            {
                var branches = _mapper.Map<List<Branch>>(item.Branches);
                foreach (var branch in branches)
                {
                    branch.AttractionId = existingAttraction.AttractionId;
                    await _branchRepository.Add(branch);
                }
                return _mapper.Map<AttractionDto>(existingAttraction);
            }
        }

        public async Task<AttractionDto> Update(int id, AttractionDto item)
        {
            var entity = _mapper.Map<Attraction>(item);
            var updatedAttraction = await _repository.Update(id, entity);
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
    }
}
