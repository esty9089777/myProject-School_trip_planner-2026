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
    public class TripService : ITripService, IsExist<TripDto>
    {
        private readonly IRepository<Trip> _repository;
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly IRepository<Route> _routeRepository;

        public TripService(IRepository<Trip> repository, IMapper mapper, IBranchRepository branchRepository, IRepository<Route> routeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _branchRepository = branchRepository;
            _routeRepository = routeRepository;
        }

        public async Task<TripDto> Add(TripDto item)
        {
            var entity = _mapper.Map<Trip>(item);
            var addedEntity = await _repository.Add(entity);
            return _mapper.Map<TripDto>(addedEntity);
        }

        public async Task<TripDto> GenerateSmartTrip(UserDto user, TripRequestDto request)
        {
            var allAttractiions = await _branchRepository.GetAll();
            var allRoutes = await _routeRepository.GetAll();

            var newTrip = new TripDto
            {
                UserEmail = user.UserEmail,
                UserName = user.UserName,

                Routes = new List<RouteDto>(),
                Branches = new List<BranchDto>()
            };

            return await Add(newTrip);
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

        public async Task<TripDto> Exist(TripDto trip)
        {
            var list = await GetAll();
            return list.FirstOrDefault(a => a.TripId == trip.TripId);
        }
    }
}
