using System.Threading.Tasks;
using Japp.BusinessLayer.Services.Jobs;
using Japp.Core.DTOs.Job;
using Japp.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Japp.API.Controllers
{
    public class JobsController : BaseApiController
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        public async Task<ActionResult<JobDto>> CreateJob([FromBody] CreateJobDto createJobDto)
        {
            var job = await _jobService.CreateJob(createJobDto);

            return (job == null) ?
                NotFound() :
                Created("Job is successfully created!", job);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JobDto>> UpdateJob([FromRoute] int id, [FromBody] UpdateJobDto updateJobDto)
        {
            if (id != updateJobDto.Id) {
                return BadRequest("Ids are not the same!");
            }
            var job = await _jobService.UpdateJob(updateJobDto);

            return (job == null) ?
                NotFound() :
                Ok(job);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJob([FromRoute] int id)
        {
            await _jobService.DeleteJob(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResult<JobDto, JobFilterParamsDto>>> GetJobs([FromQuery] Params<JobFilterParamsDto> @params)
        {
            var jobs = await _jobService.GetJobs(@params);

            return (jobs == null) ?
                NotFound() :
                Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob([FromRoute] int id)
        {
            var job = await _jobService.GetJob(id);

            return (job == null) ?
                NotFound() :
                Ok(job); 
        }

        [HttpGet("/company/{companyId}")]
        public async Task<ActionResult<PaginationResult<JobDto, JobFilterParamsDto>>> GetCompanyJob([FromRoute] int companyId)
        {
            var jobs = await _jobService.GetCompanyJobs(companyId);

            return (jobs == null) ?
                NotFound() :
                Ok(jobs);
        }
    }
}