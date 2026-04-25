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
    public class AttractionRepository : IRepository<Attraction>
    {
        private readonly IContext _ctx;
        private readonly IMapper _mapper;
        public AttractionRepository(IContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<Attraction> Add(Attraction item)
        {
            await _ctx.Attractions.AddAsync(item);
            await _ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var a = await _ctx.Attractions.FirstOrDefaultAsync(x => x.AttractionId == id);
            if(a == null)
            {
                throw new Exception("Attraction not found");
            }
            _ctx.Attractions.Remove(a);
            await _ctx.Save();
        }

        public async Task<List<Attraction>> GetAll()
        {
            return await _ctx.Attractions.ToListAsync();
        }

        public async Task<Attraction> GetById(int id)
        {
            return await _ctx.Attractions.FirstOrDefaultAsync(x => x.AttractionId == id);
        }

        public async Task<Attraction> Update(int id, Attraction item)
        {
            var existingAttraction = await _ctx.Attractions.FirstOrDefaultAsync(a => a.AttractionId == id);
            if (existingAttraction == null)
            {
                throw new Exception("Attraction not found");
            }

            _mapper.Map(item, existingAttraction);
            await _ctx.Save();
            return existingAttraction;
        }
    }
}
