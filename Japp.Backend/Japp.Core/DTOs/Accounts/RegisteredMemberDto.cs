using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Member;

namespace Japp.Core.DTOs.Accounts
{
    public class RegisteredMemberDto
    {
        public MemberDto MemberDto { get; set; }
        public string Token { get; set; }
    }
}