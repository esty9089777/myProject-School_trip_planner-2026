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
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _repository;
        private readonly IMapper _mapper;
        public AvailabilityService(IAvailabilityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AvailabilityDto> Add(AvailabilityDto item)
        {
            var entity = _mapper.Map<Availability>(item);
            var addedEntity = await _repository.Add(entity);
            return _mapper.Map<AvailabilityDto>(addedEntity);
        }

        public async Task Delete(int id)
        {
            var availability = await _repository.GetById(id);
            if (availability == null)
            {
                throw new KeyNotFoundException($"Availability with id {id} not found.");
            }
            await _repository.Delete(id);
        }

        public async Task<List<AvailabilityDto>> GetAll()
        {
            var availabilities = await _repository.GetAll();
            var availabilityDtos = _mapper.Map<List<AvailabilityDto>>(availabilities);
            return availabilityDtos;
        }

        public Task<AvailabilityDto> GetAvailabilityByAttractionId(int attractionId)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityDto> GetAvailabilityByBranchId(int branchId)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityDto> GetAvailabilityByRouteId(int routeId)
        {
            throw new NotImplementedException();
        }

        public async Task<AvailabilityDto> GetById(int id)
        {
            var availability = await _repository.GetById(id);
            if (availability == null)
            {
                throw new KeyNotFoundException($"Availability with id {id} not found.");
            }
            var availabilityDto = _mapper.Map<AvailabilityDto>(availability);
            return availabilityDto;
        }

        public Task<AvailabilityDto> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityDto> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time)
        {
            throw new NotImplementedException();
        }

        public async Task<AvailabilityDto> Update(int id, AvailabilityDto item)
        {
            var availability = await _repository.GetById(id);
            if (availability == null)
            {
                throw new Exception("Availability not found");
            }
            _mapper.Map(item, availability);
            var updatedAvailability = await _repository.Update(availability.AvailabilityId, availability);
            return _mapper.Map<AvailabilityDto>(updatedAvailability);
        }
    }
}