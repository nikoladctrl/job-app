using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Comment;
using Japp.Core.Helpers;

namespace Japp.BusinessLayer.Services.Comments
{
    public interface ICommentService
    {
        Task<CommentDto> CreateComment(CreateCommentDto createCommentDto);
        Task<CommentDto> UpdateComment(UpdateCommentDto updateCommentDto);
        Task DeleteComment(int id);
        Task<PaginationResult<CommentDto, CommentFilterParamsDto>> GetComments(Params<CommentFilterParamsDto> @params);
        Task<CommentDto> GetComment(int id);
    }
}