using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japp.Core.DTOs.Accounts
{
    public class ResetPasswordDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}