using AutoMapper;
using Japp.Core.DTOs.Comment;
using Japp.Core.Entities;
using Japp.Core.Helpers;

namespace Japp.BusinessLayer.Mappings
{
    public class MappingComments : Profile
    {
        public MappingComments()
        {
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<UpdateCommentDto, Comment>();
            CreateMap<Comment, CommentDto>();
            CreateMap<PaginationResult<Comment, CommentFilterParamsDto>, PaginationResult<CommentDto, CommentFilterParamsDto>>();
            CreateMap<Comment, int>().ConvertUsing(src => src.Id);
        }
    }
}