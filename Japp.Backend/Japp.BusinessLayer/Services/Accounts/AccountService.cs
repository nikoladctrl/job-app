using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Japp.BusinessLayer.Services.Tokens;
using Japp.Core.DTOs.Accounts;
using Japp.Core.DTOs.Member;
using Japp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Japp.BusinessLayer.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountService(
            UserManager<Member> userManager, 
            SignInManager<Member> signInManager, 
            IMapper mapper, 
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<object> Register(RegisterMemberDto registerMemberDto)
        {
            var member = _mapper.Map<Member>(registerMemberDto);
            var result = await _userManager.CreateAsync(member, registerMemberDto.Password);
            
            return (result.Succeeded) ? _mapper.Map<MemberDto>(member) : result;
        }
        
        public async Task<object> Login(LoginMemberDto loginMemberDto)
        {
            var member = await _userManager.FindByEmailAsync(loginMemberDto.Email);

            if (member != null)
            {
                var verifyPassword = _userManager.PasswordHasher.VerifyHashedPassword(member, member.PasswordHash, loginMemberDto.Password);
                // var result = await _signInManager.PasswordSignInAsync(loginMemberDto.Email, loginMemberDto.Password, true, lockoutOnFailure: false);

                if (verifyPassword == PasswordVerificationResult.Success)
                {
                    if (member.IsAdmin || member.IsAdmin == loginMemberDto.IsAdmin)
                    {
                        var token = await _tokenService.GetToken(loginMemberDto);
                        return new RegisteredMemberDto 
                        {
                            MemberDto = _mapper.Map<MemberDto>(member),
                            Token = token
                        };
                    }
                }
            }
            return null;
        }

    }
}