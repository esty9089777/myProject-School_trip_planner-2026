using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myProjectTrips.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IContext _ctx;
        private readonly IMapper _mapper;
        public BranchRepository(IContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<Branch> Add(Branch item)
        {
            await _ctx.Branches.AddAsync(item);
            await _ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var b = await _ctx.Branches.FirstOrDefaultAsync(x => x.BranchId == id);
            if (b == null)
            {
                throw new Exception("Branch not found");
            }
            _ctx.Branches.Remove(b);
            await _ctx.Save();
        }

        public async Task<List<Branch>> GetAll()
        {
            return await _ctx.Branches.ToListAsync();
        }

        public async Task<List<Branch>> GetBranchesByAttractionId(int attractionId)
        {
            return await _ctx.Branches
                    .Where(x => x.AttractionId == attractionId)
                    .ToListAsync();
        }

        public Task<Branch> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> GetById(int id)
        {
            return _ctx.Branches.FirstOrDefaultAsync(x => x.BranchId == id);
        }

        public async Task<List<Branch>> GetNearbyBranches(double lat, double lng)
        {
            double offset = 0.1;

            return await _ctx.Branches
                .Where(x => x.Latitude >= lat - offset && x.Latitude <= lat + offset &&
                            x.Longitude >= lng - offset && x.Longitude <= lng + offset)
                .ToListAsync();
        }

        public async Task<Branch> Update(int id, Branch item)
        {
            var existingBranch = await _ctx.Branches.FirstOrDefaultAsync(a => a.BranchId == id);
            if (existingBranch == null)
            {
                throw new Exception("Branch not found");
            }

            _mapper.Map(item, existingBranch);
            await _ctx.Save();
            return existingBranch;
        }
    }
}
