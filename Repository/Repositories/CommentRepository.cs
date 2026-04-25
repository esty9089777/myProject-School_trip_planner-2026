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
        private readonly IContext ctx;
        public CommentRepository(IContext context)
        {
            ctx = context;
        }

        public async Task<Comment> Add(Comment item)
        {
            await ctx.Comments.AddAsync(item);
            await ctx.Save();
            return item;
        }

        public async Task Delete(int id)
        {
            var c = ctx.Comments.FirstOrDefault(x => x.CommentId == id);
            if (c == null)
            {
                throw new Exception("Comment not found");
            }
            ctx.Comments.Remove(c);
            await ctx.Save();
        }

        public async Task<List<Comment>> GetAll()
        {
            return await ctx.Comments.ToListAsync();
        }

        public async Task<Comment> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetById(int id)
        {
            return ctx.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
        }

        public async Task<List<Comment>> GetCommentByBranchId(int branchId)
        {
            return await ctx.Comments
                    .Where(x => x.BranchId == branchId)
                    .ToListAsync();
        }

        public async Task<List<Comment>> GetCommentByRouteId(int routeId)
        {
            return await ctx.Comments
                    .Where(x => x.RouteId == routeId)
                    .ToListAsync();
        }

        public async Task<Comment> Update(int id, Comment item)
        {
            var c = await ctx.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
            if (c == null)
            {
                throw new Exception("Comment not found");
            }
            c.SchoolName = item.SchoolName;
            c.CommentId = item.CommentId;
            c.BranchId = item.BranchId;
            c.RouteId = item.RouteId;
            c.myComment = item.myComment;
            c.DateCommon = item.DateCommon;
            c.Branch = item.Branch;
            c.Route = item.Route;
            await ctx.Save();
            return c;
        }
    }
}
