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
    internal class BranchRepository : IBranchRepository
    {
        private readonly IContext ctx;
        public BranchRepository(IContext context)
        {
            ctx = context;
        }

        public async Task<Branch> Add(Branch item)
        {
            await ctx.Branches.AddAsync(item);
            await ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var b = ctx.Branches.FirstOrDefault(x => x.BranchId == id);
            if (b == null)
            {
                throw new Exception("Branch not found");
            }
            ctx.Branches.Remove(b);
            await ctx.Save();
        }

        public async Task<List<Branch>> GetAll()
        {
            return await ctx.Branches.ToListAsync();
        }

        public async Task<List<Branch>> GetBranchesByAttractionId(int attractionId)
        {
            return await ctx.Branches
                    .Where(x => x.BranchId == attractionId)
                    .ToListAsync();
        }

        public Task<Branch> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> GetById(int id)
        {
            return ctx.Branches.FirstOrDefaultAsync(x => x.BranchId == id);
        }

        public async Task<List<Branch>> GetNearbyBranches(double lat, double lng)
        {
            double offset = 0.1;

            return await ctx.Branches
                .Where(x => x.Latitude >= lat - offset && x.Latitude <= lat + offset &&
                            x.Longitude >= lng - offset && x.Longitude <= lng + offset)
                .ToListAsync();
        }

        public async Task<Branch> Update(int id, Branch item)
        {
            var b = await ctx.Branches.FirstOrDefaultAsync(x => x.BranchId == id);
            if (b == null)
            {
                throw new Exception("Branches not found");
            }
            b.BranchId = id;
            b.AttractionId = item.AttractionId;
            b.BranchId = item.BranchId;
            b.BranchName = item.BranchName;
            b.Attraction = item.Attraction;
            b.Duration = item.Duration;
            b.Latitude = item.Latitude;
            b.Longitude = item.Longitude;
            b.AgeGroup = item.AgeGroup;
            b.Points = item.Points;
            b.attractionCategory = item.attractionCategory;
            b.CommentsList = item.CommentsList;
            b.ImageUrl = item.ImageUrl;
            b.IsFree = item.IsFree;
            b.IsWet = item.IsWet;
            await ctx.Save();
            return b;
        }
    }
}
