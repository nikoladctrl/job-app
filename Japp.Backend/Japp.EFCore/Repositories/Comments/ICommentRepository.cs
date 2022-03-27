using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Comment;
using Japp.Core.Entities;
using Japp.Core.Helpers;

namespace Japp.EFCore.Repositories.Comments
{
    public interface ICommentRepository
    {
        Task<Comment> CreateComment(Comment comment);
        Task<Comment> UpdateComment(Comment comment);
        Task DeleteComment(int id);
        Task<PaginationResult<Comment, CommentFilterParamsDto>> GetComments(Params<CommentFilterParamsDto> @params);
        Task<Comment> GetComment(int id);
    }
}