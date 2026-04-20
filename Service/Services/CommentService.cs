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
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public CommentService(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> GetAll()
        {
            var comments = await _repository.GetAll();
            var commentsDtos = _mapper.Map<List<CommentDto>>(comments);
            return commentsDtos;
        }

        public async Task<CommentDto> GetById(int id)
        {
            var comment = await _repository.GetById(id);
            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }

        public void Add(Comment item)
        {
        }

        public void Update(Comment item)
        {
        }

        public void Delete(int id)
        {
        }

        public void AddComment(int userId, int? branchId, int? routeId, string content)
        {
            throw new NotImplementedException();
        }

        public CommentDto GetCommentById(int commentId)
        {
            throw new NotImplementedException();
        }

        public List<CommentDto> GetCommentByBranchId(int branchId)
        {
            throw new NotImplementedException();
        }

        public List<CommentDto> GetCommentByRouteId(int routeId)
        {
            throw new NotImplementedException();
        }

        public List<CommentDto> GetCommentsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateComment(int commentId, string content)
        {
            throw new NotImplementedException();
        }

        Task<List<Comment>> IService<Comment>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Comment> IService<Comment>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Comment> IService<Comment>.Add(Comment item)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Update(int id, Comment item)
        {
            throw new NotImplementedException();
        }

        Task IService<Comment>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
