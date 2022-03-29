using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Job;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Context;
using Japp.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.Repositories.Jobs
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        private readonly IUnitOfWork<Job> _unitOfWork;
        public JobRepository(DataContext context, IUnitOfWork<Job> unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;            
        }

        public async Task<Job> CreateJob(Job job)
        {
            var newJob = await _unitOfWork.Add(job);

            return await GetJob(newJob.Id);
        }

        public async Task<Job> UpdateJob(Job job)
        {
            var updatedJob = await _unitOfWork.Update(job);

            return await GetJob(updatedJob.Id);
        }

        public async Task DeleteJob(int id)
        {
            var job = await GetJob(id);

            await _unitOfWork.Delete(job);
        }

        public async Task<PaginationResult<Job, JobFilterParamsDto>> GetJobs(Params<JobFilterParamsDto> @params)
        {
            var query = MakeQuery(@params);

            var total = query.Count();

            var jobs = await Paginate(query, @params.Page, @params.Size).ToListAsync();

            return new PaginationResult<Job, JobFilterParamsDto>(jobs, @params.Page, @params.Size, total, @params.FilteringParams);
        }

        public async Task<Job> GetJob(int id)
        {
            return await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<PaginationResult<Job, JobFilterParamsDto>> GetCompanyJobs(int companyId)
        {
            var query = _context.Jobs.Where(j => j.CompanyId == companyId).AsQueryable();

            var total = query.Count();

            var jobs = await Paginate(query, 1, 12).ToListAsync();

            return new PaginationResult<Job, JobFilterParamsDto>(jobs, 1, 12, total);
        }

        private IQueryable<Job> MakeQuery(Params<JobFilterParamsDto> @params)
        {
            var query = _context.Jobs
                                .Include(j => j.Company).ThenInclude(c => c.CompanyTechnologies).ThenInclude(ct => ct.Technology)
                                .OrderBy(o => o.Id)
                                .AsQueryable();

            if (!String.IsNullOrEmpty(@params.FilteringParams?.Employer)) {
                query = query.Where(j => j.Company.Name.ToLower().Contains(@params.FilteringParams.Employer.ToLower()));
            }

            if (!String.IsNullOrEmpty(@params.FilteringParams?.Technology)) {
                query = query.Where(j => j.Company.CompanyTechnologies.Any(t => t.Technology.Name.ToLower().Contains(@params.FilteringParams.Technology.ToLower())));
            }

            if (!String.IsNullOrEmpty(@params.FilteringParams?.Place)) {
                query = query.Where(j => j.Company.Address.ToLower().Contains(@params.FilteringParams.Place.ToLower()));
            }

            if (!String.IsNullOrEmpty(@params.FilteringParams?.Place)) {
                query = query.Where(j => j.Seniority.ToString().ToLower() == @params.FilteringParams.Seniority.ToLower());
            }

            if (@params.FilteringParams?.CreateDate != null) {
                query = query.Where(j => j.CreatedOn == @params.FilteringParams.CreateDate);
            }

            if (@params.FilteringParams?.IsRemote != null) {
                query = query.Where(j => j.IsRemote == @params.FilteringParams.IsRemote);
            }

            if (@params.FilteringParams?.IsOnlineInterview != null) {
                query = query.Where(j => j.IsOnlineInterview == @params.FilteringParams.IsOnlineInterview);
            }    
            
            return query;
        }

        private IQueryable<Job> Paginate(IQueryable<Job> query, int page, int size)
        {
            return query
                    .Skip((page - 1) * size)
                    .Take(size)
                    .AsSingleQuery();
        }
    }
}