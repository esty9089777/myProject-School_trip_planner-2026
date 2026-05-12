using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CommentService : ICommentService, IsExist<CommentDto>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository repository, IMapper mapper)
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
            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with id {id} not found.");
            }
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task DeleteProtected(int commentId, int currentUserId, bool isAdmin)
        {
            var comment = await _repository.GetById(commentId);

            if (comment == null)
                throw new KeyNotFoundException("התגובה לא נמצאה");

            bool isOwner = false;

            if (comment.Branch?.Attraction != null)
            {
                isOwner = comment.Branch.Attraction.CreatorId == currentUserId;
            }
            else if (comment.Route != null)
            {
                isOwner = comment.Route.CreatorId == currentUserId;
            }

            if (isOwner || isAdmin)
            {
                await _repository.Delete(commentId);
            }
            else
            {
                throw new UnauthorizedAccessException("אין לך הרשאה למחוק תגובה זו");
            }
        }

        public async Task<List<CommentDto>> GetCommentByBranchId(int branchId)
        {
            var comments = await _repository.GetCommentByBranchId(branchId);
            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<List<CommentDto>> GetCommentByRouteId(int routeId)
        {
            var comments = await _repository.GetCommentByRouteId(routeId);
            return _mapper.Map<List<CommentDto>>(comments);
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

        public async Task<CommentDto> Exist(CommentDto comment)
        {
            try
            {
                return await GetById(comment.CommentId);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public Task<CommentDto> Exist(LoginDto l)
        {
            throw new NotImplementedException();
        }
    }
}
