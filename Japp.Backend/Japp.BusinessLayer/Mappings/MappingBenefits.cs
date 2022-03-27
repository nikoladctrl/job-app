using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.DTOs.Benefit;
using Japp.Core.Entities;

namespace Japp.BusinessLayer.Mappings
{
    public class MappingBenefits : Profile
    {
        public MappingBenefits()
        {
            CreateMap<CreateBenefitDto, Benefit>();
            CreateMap<UpdateBenefitDto, Benefit>();
            CreateMap<Benefit, BenefitDto>();
            CreateMap<Benefit, int>().ConvertUsing(src => src.Id);
        }
    }
}