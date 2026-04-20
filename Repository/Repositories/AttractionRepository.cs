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
    public class AttractionRepository : IRepository<Attraction>
    {
        private readonly IContext ctx;

        public async Task<Attraction> Add(Attraction item)
        {
            ctx.Attractions.AddAsync(item);
            await ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var a = ctx.Attractions.FirstOrDefault(x=>x.AttractionId == id);
            ctx.Attractions.Remove(a);
            await ctx.Save();
        }

        public async Task<List<Attraction>> GetAll()
        {
            return await ctx.Attractions.ToListAsync();
        }

        public async Task<Attraction> GetByEmail(string email)
        {
            return await ctx.Attractions.FirstOrDefaultAsync(x => x.AttraName == email);
        }

        public async Task<Attraction> GetById(int id)
        {
            return await ctx.Attractions.FirstOrDefaultAsync(x => x.AttractionId == id);
        }

        public async Task<Attraction> Update(int id, Attraction item)
        {
            var a = await ctx.Attractions.FirstOrDefaultAsync(x => x.AttractionId == id);
            a.AttraName = item.AttraName;
            a.Branches = item.Branches;
            a.AttractionId = id;
            a.Creator = item.Creator;
            a.CreatorId = item.CreatorId;
            a.Description = item.Description;
            a.ImageUrl = item.ImageUrl;
            await ctx.Save();
            return a;
        }
    }
}
