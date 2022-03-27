using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.DTOs.Company;
using Japp.Core.DTOs.Job;
using Japp.Core.Entities;
using Japp.Core.Helpers;

namespace Japp.BusinessLayer.Mappings
{
    public class MappingCompanies : Profile
    {
        public MappingCompanies()
        {
            CreateMap<CreateCompanyDto, Company>();
            
            CreateMap<UpdateCompanyDto, Company>()
                .ForMember(dest => dest.ThumbnailImage, opt => opt.MapFrom(src => Convert.FromBase64String(src.ThumbnailImage)));
            
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.ThumbnailImage, opt => opt.MapFrom(src => Convert.ToBase64String(src.ThumbnailImage)));
            
            CreateMap<PaginationResult<Company, CompanyFilterParamsDto>, PaginationResult<CompanyDto, CompanyFilterParamsDto>>();
            
            CreateMap<Company, int>().ConvertUsing(src => src.Id);
        }
    }
}