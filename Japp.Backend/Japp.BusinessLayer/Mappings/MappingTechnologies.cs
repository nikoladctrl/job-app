using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.Entities;

namespace Japp.BusinessLayer.Mappings
{
    public class MappingTechnologies : Profile
    {
        public MappingTechnologies()
        {
            CreateMap<Technology, int>().ConvertUsing(src => src.Id);
        }
    }
}