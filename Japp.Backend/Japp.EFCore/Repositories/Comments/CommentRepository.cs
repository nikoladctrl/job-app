using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Comment;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Context;
using Japp.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.Repositories.Comments
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly IUnitOfWork<Comment> _unitOfWork;
        public CommentRepository(DataContext context, IUnitOfWork<Comment> unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;            
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            var newComment = await _unitOfWork.Add(comment);

            return await GetComment(newComment.Id);
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            var updatedComment = await _unitOfWork.Update(comment);

            return await GetComment(updatedComment.Id);
        }

        public async Task DeleteComment(int id)
        {
            var comment = await GetComment(id);

            await _unitOfWork.Delete(comment);
        }

        public async Task<PaginationResult<Comment, CommentFilterParamsDto>> GetComments(Params<CommentFilterParamsDto> @params)
        {
            var query = MakeQuery(@params);

            var total = query.Count();

            var comments = await Paginate(query, @params.Page, @params.Size).ToListAsync();

            return new PaginationResult<Comment, CommentFilterParamsDto>(comments, @params.Page, @params.Size, total, @params.FilteringParams);
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        private IQueryable<Comment> MakeQuery(Params<CommentFilterParamsDto> @params)
        {
            var query = _context.Comments
                                .Include(c => c.Company)
                                .OrderBy(o => o.Id)
                                .AsQueryable();

            if (!String.IsNullOrEmpty(@params.FilteringParams?.Position)) {
                query = query.Where(c => c.Title.ToLower().Contains(@params.FilteringParams.Position.ToLower()));
            }

            if (!String.IsNullOrEmpty(@params.FilteringParams?.CompanyName)) {
                query = query.Where(c => c.Company.Name.ToLower().Contains(@params.FilteringParams.CompanyName.ToLower()));
            }
            
            if (!String.IsNullOrEmpty(@params.FilteringParams?.Town)) {
                query = query.Where(c => c.Company.Address == @params.FilteringParams.Town);
            }

            if (!String.IsNullOrEmpty(@params.FilteringParams?.CommentType)) {
                query = query.Where(c => c.CommentType.ToString().ToLower() == @params.FilteringParams.CommentType);
            }

            return query;
        }
        
        private IQueryable<Comment> Paginate(IQueryable<Comment> query, int page, int size)
        {
             return query
                    .Skip((page - 1) * size)
                    .Take(size)
                    .AsSingleQuery();
        }
    }
}