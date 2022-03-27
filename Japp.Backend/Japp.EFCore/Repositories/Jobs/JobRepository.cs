using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Job;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.Repositories.Jobs
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;
        public JobRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Job> CreateJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return await GetJob(job.Id);
        }

        public async Task<Job> UpdateJob(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();

            return await GetJob(job.Id);
        }

        public async Task DeleteJob(int id)
        {
            var job = await GetJob(id);

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
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