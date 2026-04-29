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
    public class TripService : ITripService
    {
        private readonly IRepository<Trip> _repository;
        private readonly IMapper _mapper;

        public TripService(IRepository<Trip> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TripDto> Add(TripDto item)
        {
            var entity = _mapper.Map<Trip>(item);
            var addedEntity = await _repository.Add(entity);
            return _mapper.Map<TripDto>(addedEntity);
        }

        public async Task Delete(int id)
        {
            var trip = await _repository.GetById(id);
            if (trip == null)
            {
                throw new KeyNotFoundException($"Trip with id {id} not found.");
            }
            await _repository.Delete(id);
        }

        public async Task<List<TripDto>> GetAll()
        {
            var trips = await _repository.GetAll();
            var tripDtos = _mapper.Map<List<TripDto>>(trips);
            return tripDtos;
        }

        public async Task<TripDto> GetById(int id)
        {
            var trip = await _repository.GetById(id);
            if (trip == null)
            {
                throw new KeyNotFoundException($"Trip with id {id} not found.");
            }
            var tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }

        public async Task<List<TripDto>> GetTripsByUserId(int userId)
        {
            var trips = await _repository.GetAll();
            var userTrips = trips.Where(t => t.UserId == userId).ToList();
            return _mapper.Map<List<TripDto>>(userTrips);
        }

        public async Task<TripDto> Update(int id, TripDto item)
        {
            var trip = await _repository.GetById(id);
            if (trip == null)
            {
                throw new KeyNotFoundException($"Trip with id {id} not found.");
            }
            _mapper.Map(item, trip);
            var updatedTrip = await _repository.Update(trip.TripId, trip);
            return _mapper.Map<TripDto>(updatedTrip);
        }
    }
}
