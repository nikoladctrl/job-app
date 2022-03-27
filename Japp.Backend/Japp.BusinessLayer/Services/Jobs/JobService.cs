using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.DTOs.Job;
using Japp.Core.Entities;
using Japp.Core.Helpers;
using Japp.EFCore.Repositories.Jobs;

namespace Japp.BusinessLayer.Services.Jobs
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<JobDto> CreateJob(CreateJobDto createJobDto)
        {
            return _mapper.Map<JobDto>(await _jobRepository.CreateJob(_mapper.Map<Job>(createJobDto)));
        }

        public async Task<JobDto> UpdateJob(UpdateJobDto updateJobDto)
        {
            var job = await _jobRepository.GetJob(updateJobDto.Id);
            var jobToUpdate = _mapper.Map<UpdateJobDto, Job>(updateJobDto, job);
            return _mapper.Map<JobDto>(await _jobRepository.UpdateJob(jobToUpdate));
        }
        
        public async Task DeleteJob(int id)
        {
            await _jobRepository.DeleteJob(id);
        }

        public async Task<PaginationResult<JobDto, JobFilterParamsDto>> GetJobs(Params<JobFilterParamsDto> @params)
        {
            return _mapper.Map<PaginationResult<JobDto, JobFilterParamsDto>>(await _jobRepository.GetJobs(@params));
        }

        public async Task<JobDto> GetJob(int id)
        {
            return _mapper.Map<JobDto>(await _jobRepository.GetJob(id));
        }

        public async Task<PaginationResult<JobDto,  JobFilterParamsDto>> GetCompanyJobs(int companyId)
        {
            return _mapper.Map<PaginationResult<JobDto, JobFilterParamsDto>>(await _jobRepository.GetCompanyJobs(companyId));
        }
    }
}