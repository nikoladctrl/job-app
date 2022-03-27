using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Accounts;
using Japp.Core.DTOs.Member;

namespace Japp.BusinessLayer.Services.Accounts
{
    public interface IAccountService
    {
        Task<object> Register(RegisterMemberDto registerMemberDto);
        Task<object> Login(LoginMemberDto loginMemberDto);
    }
}