using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Job;
using Japp.Core.Entities;
using Japp.Core.Helpers;

namespace Japp.EFCore.Repositories.Jobs
{
    public interface IJobRepository
    {
        Task<Job> CreateJob(Job job);
        Task<Job> UpdateJob(Job job);
        Task DeleteJob(int id);
        Task<PaginationResult<Job, JobFilterParamsDto>> GetJobs(Params<JobFilterParamsDto> @params);
        Task<Job> GetJob(int id);
        Task<PaginationResult<Job, JobFilterParamsDto>> GetCompanyJobs(int companyId);
    }
}