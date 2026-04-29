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

        public async Task<CommentDto> Add(CommentDto item)
        {
            var entity = _mapper.Map<Comment>(item);
            var addedEntity = await _repository.Add(entity);
            return _mapper.Map<CommentDto>(addedEntity);
        }

        public async Task Delete(int id)
        {
            var comment = await _repository.GetById(id);
            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with id {id} not found.");
            }
            await _repository.Delete(id);
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

        public Task<List<CommentDto>> GetCommentByBranchId(int branchId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDto>> GetCommentByRouteId(int routeId)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentDto> Update(int id, CommentDto item)
        {
            var comment = await _repository.GetById(id);
            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with id {id} not found.");
            }
            _mapper.Map(item, comment);
            var updatedComment = await _repository.Update(comment.CommentId, comment);
            return _mapper.Map<CommentDto>(updatedComment);
        }
    }
}
