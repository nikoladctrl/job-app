using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Member
{
    public class MemberDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}