using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.DTOs.Accounts;

namespace Japp.BusinessLayer.Services.Tokens
{
    public interface ITokenService
    {
        Task<string> GetToken(LoginMemberDto loginMemberDto);
    }
}