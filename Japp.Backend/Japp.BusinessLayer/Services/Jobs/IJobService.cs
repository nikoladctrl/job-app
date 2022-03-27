using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Job;
using Japp.Core.Helpers;

namespace Japp.BusinessLayer.Services.Jobs
{
    public interface IJobService
    {
        Task<JobDto> CreateJob(CreateJobDto createJobDto);
        Task<JobDto> UpdateJob(UpdateJobDto updateJobDto);
        Task DeleteJob(int id);
        Task<PaginationResult<JobDto, JobFilterParamsDto>> GetJobs(Params<JobFilterParamsDto> @params);
        Task<JobDto> GetJob(int id);
        Task<PaginationResult<JobDto, JobFilterParamsDto>> GetCompanyJobs(int companyId);
    }
}