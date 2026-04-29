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

        public async Task<List<AvailabilityDto>> GetAvailabilityByAttractionId(int attractionId)
        {
            var availabilities = await _repository.GetAll();
            var attractionAvailability = availabilities.Where(a => a.AttractionId == attractionId).ToList();

            if (!attractionAvailability.Any())
            {
                throw new KeyNotFoundException($"No availability defined for attraction {attractionId}.");
            }

            return _mapper.Map<List<AvailabilityDto>>(attractionAvailability);
        }

        public async Task<List<AvailabilityDto>> GetAvailabilityByBranchId(int branchId)
        {
            var availabilities = await _repository.GetAll();
            var branchAvailability = availabilities.Where(a => a.BranchId == branchId).ToList();

            if (!branchAvailability.Any())
            {
                throw new KeyNotFoundException($"No availability defined for branch {branchId}.");
            }

            return _mapper.Map<List<AvailabilityDto>>(branchAvailability);
        }

        public async Task<List<AvailabilityDto>> GetAvailabilityByRouteId(int routeId)
        {
            var availabilities = await _repository.GetAll();
            var routeAvailability = availabilities.Where(a => a.RouteId == routeId).ToList();

            if (!routeAvailability.Any())
            {
                throw new KeyNotFoundException($"No availability defined for route {routeId}.");
            }

            return _mapper.Map<List<AvailabilityDto>>(routeAvailability);
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

        public async Task<AvailabilityDto> IsBranchAvailable(int branchId, DayOfWeek day, TimeOnly time)
        {
            var availabilities = await _repository.GetAll();
            var branchAvailability = availabilities.FirstOrDefault(a => a.BranchId == branchId && a.Day == day);

            if (branchAvailability == null)
            {
                throw new KeyNotFoundException($"No availability defined for branch {branchId} on {day}.");
            }

            bool isOpen = time >= branchAvailability.OpenTime && time <= branchAvailability.CloseTime;

            if (isOpen)
            {
                return _mapper.Map<AvailabilityDto>(branchAvailability);
            }

            throw new Exception($"Branch {branchId} is closed at {time} on {day}.");
        }

        public async Task<AvailabilityDto> IsRouteAvailable(int routeId, DayOfWeek day, TimeOnly time)
        {
            var availabilities = await _repository.GetAll();
            var routeAvailability = availabilities.FirstOrDefault(a => a.RouteId == routeId && a.Day == day);

            if (routeAvailability == null)
            {
                throw new KeyNotFoundException($"No availability defined for route {routeId} on {day}.");
            }

            bool isOpen = time >= routeAvailability.OpenTime && time <= routeAvailability.CloseTime;

            if (isOpen)
            {
                return _mapper.Map<AvailabilityDto>(routeAvailability);
            }

            throw new Exception($"Route {routeId} is closed at {time} on {day}.");
        }

        public async Task<AvailabilityDto> Update(int id, AvailabilityDto item)
        {
            var availability = await _repository.GetById(id);
            if (availability == null)
            {
                throw new KeyNotFoundException($"Availability with id {id} not found.");
            }
            _mapper.Map(item, availability);
            var updatedAvailability = await _repository.Update(availability.AvailabilityId, availability);
            return _mapper.Map<AvailabilityDto>(updatedAvailability);
        }
    }
}