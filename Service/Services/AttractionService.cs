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
    public class AttractionService : IAttractionService
    {
        private readonly IRepository<Attraction> _repository;
        private readonly IMapper _mapper;

        public AttractionService(IRepository<Attraction> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Attraction>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Attraction> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Attraction> Add(Attraction item)
        {
            return await _repository.Add(item);
        }

        public async Task<Attraction> Update(int id, Attraction item)
        {
            return await _repository.Update(id, item);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public Task<AttractionDto> AddAttraction(AttractionDto attractionDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteAttraction(int attractionId)
        {
            throw new NotImplementedException();
        }

        public AttractionDto GetAttractionById(int attractionId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAttraction(int attractionId, AttractionDto attractionDto)
        {
            throw new NotImplementedException();
        }

        AttractionDto IAttractionService.AddAttraction(AttractionDto attractionDto)
        {
            throw new NotImplementedException();
        }

        Task IAttractionService.UpdateAttraction(int attractionId, AttractionDto attractionDto)
        {
            throw new NotImplementedException();
        }

        Task IAttractionService.DeleteAttraction(int attractionId)
        {
            throw new NotImplementedException();
        }
    }
}
