using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.Core.DTOs.Accounts;
using Japp.Core.DTOs.Member;
using Japp.Core.Entities;

namespace Japp.BusinessLayer.Mappings
{
    public class MappingMembers : Profile
    {
        public MappingMembers()
        {
            CreateMap<RegisterMemberDto, Member>();
            CreateMap<Member, RegisteredMemberDto>();
            CreateMap<Member, MemberDto>();

        }
    }
}