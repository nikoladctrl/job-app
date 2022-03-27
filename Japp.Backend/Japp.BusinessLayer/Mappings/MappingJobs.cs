using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.DTOs.Job;
using Japp.Core.Entities;
using Japp.Core.Helpers;

namespace Japp.BusinessLayer.Mappings
{
    public class MappingJobs : Profile
    {
        public MappingJobs()
        {
            CreateMap<CreateJobDto, Job>()
                .ForMember(dest => dest.ExpiresOn, opt => opt.MapFrom(src => DateTime.Now.AddDays(21)));
            CreateMap<UpdateJobDto, Job>();
            CreateMap<Job, JobDto>();
            CreateMap<PaginationResult<Job, JobFilterParamsDto>, PaginationResult<JobDto, JobFilterParamsDto>>();
            CreateMap<Job, int>().ConstructUsing(src => src.Id);
        }
    }
}