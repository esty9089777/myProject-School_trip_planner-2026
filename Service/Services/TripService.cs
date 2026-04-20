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

        public void Add(Trip item)
        {
        }

        public void Update(Trip item)
        {
        }

        public void Delete(int id)
        {
        }

        public TripDto CreateTrip(TripDto tripDto)
        {
            // יצירת נסיעה חדשה
        }

        public TripDto GetTripById(int tripId)
        {
            // שליפת נסיעה לפי ID
        }

        public async Task<List<TripDto>> GetTripsByUserId(int userId)
        {
            
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
            var tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }

        List<TripDto> ITripService.GetTripsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        Task<List<Trip>> IService<Trip>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Trip> IService<Trip>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Trip> IService<Trip>.Add(Trip item)
        {
            throw new NotImplementedException();
        }

        public Task<Trip> Update(int id, Trip item)
        {
            throw new NotImplementedException();
        }

        Task IService<Trip>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
