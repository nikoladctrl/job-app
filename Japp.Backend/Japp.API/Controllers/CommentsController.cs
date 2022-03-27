using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.BusinessLayer.Services.Comments;
using Japp.Core.DTOs.Comment;
using Japp.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Japp.API.Controllers
{
    public class CommentsController : BaseApiController
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        [HttpPost]
        public async Task<ActionResult<CommentDto>> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            var Comment = await _commentService.CreateComment(createCommentDto);

            return (Comment == null) ?
                NotFound() :
                Created("Comment is successfully created!", Comment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommentDto>> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            if (id != updateCommentDto.Id) {
                return BadRequest("Ids are not the same!");
            }
            var Comment = await _commentService.UpdateComment(updateCommentDto);

            return (Comment == null) ?
                NotFound() :
                Ok(Comment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment([FromRoute] int id)
        {
            await _commentService.DeleteComment(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> GetComments([FromQuery] Params<CommentFilterParamsDto> @params)
        {
            var comments = await _commentService.GetComments(@params);

            return (comments == null) ?
                NotFound() :
                Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment([FromRoute] int id)
        {
            var Comment = await _commentService.GetComment(id);

            return (Comment == null) ?
                NotFound() :
                Ok(Comment); 
        }

        // [HttpGet("/{companyId}/company")]
        // public async Task<ActionResult<PaginationResult<CommentDto>>> GetCompanyComment([FromRoute] int companyId)
        // {
        //     var comments = await _commentService.GetCompanyComments(companyId);

        //     return (comments == null) ?
        //         NotFound() :
        //         Ok(comments);
        // }
    }
}