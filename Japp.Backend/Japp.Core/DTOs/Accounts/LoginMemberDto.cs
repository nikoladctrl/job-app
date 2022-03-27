using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Accounts
{
    public class LoginMemberDto
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}