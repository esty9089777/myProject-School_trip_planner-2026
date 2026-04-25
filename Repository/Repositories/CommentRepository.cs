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
    public class CommentRepository : ICommentRepository
    {
        private readonly IContext _ctx;
        private readonly IMapper _mapper;
        public CommentRepository(IContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<Comment> Add(Comment item)
        {
            await _ctx.Comments.AddAsync(item);
            await _ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var c = await _ctx.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
            if (c == null)
            {
                throw new Exception("Comment not found");
            }
            _ctx.Comments.Remove(c);
            await _ctx.Save();
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _ctx.Comments.ToListAsync();
        }

        public async Task<Comment> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetById(int id)
        {
            return _ctx.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
        }

        public async Task<List<Comment>> GetCommentByBranchId(int branchId)
        {
            return await _ctx.Comments
                    .Where(x => x.BranchId == branchId)
                    .ToListAsync();
        }

        public async Task<List<Comment>> GetCommentByRouteId(int routeId)
        {
            return await _ctx.Comments
                    .Where(x => x.RouteId == routeId)
                    .ToListAsync();
        }

        public async Task<Comment> Update(int id, Comment item)
        {
            var existingComment = await _ctx.Comments.FirstOrDefaultAsync(a => a.CommentId == id);
            if (existingComment == null)
            {
                throw new Exception("Comment not found");
            }

            _mapper.Map(item, existingComment);
            await _ctx.Save();
            return existingComment;
        }
    }
}
