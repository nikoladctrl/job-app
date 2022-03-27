using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.DTOs.Comment;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Repositories.Comments;

namespace Japp.BusinessLayer.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateComment(CreateCommentDto createCommentDto)
        {
            return _mapper.Map<CommentDto>(await _commentRepository.CreateComment(_mapper.Map<Comment>(createCommentDto)));
        }

        public async Task<CommentDto> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepository.GetComment(updateCommentDto.Id);
            var commentToUpdate = _mapper.Map<UpdateCommentDto, Comment>(updateCommentDto, comment);
            return _mapper.Map<CommentDto>(await _commentRepository.UpdateComment(commentToUpdate));
        }
        
        public async Task DeleteComment(int id)
        {
            await _commentRepository.DeleteComment(id);
        }

        public async Task<PaginationResult<CommentDto, CommentFilterParamsDto>> GetComments(Params<CommentFilterParamsDto> @params)
        {
            return _mapper.Map<PaginationResult<CommentDto, CommentFilterParamsDto>>(await _commentRepository.GetComments(@params));
        }

        public async Task<CommentDto> GetComment(int id)
        {
            return _mapper.Map<CommentDto>(await _commentRepository.GetComment(id));
        }
    }
}