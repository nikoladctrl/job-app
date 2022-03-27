using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Japp.Core.DTOs.Accounts;
using Japp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Japp.BusinessLayer.Services.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly IConfiguration _config;
        public TokenService(UserManager<Member> userManager, SignInManager<Member> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<string> GetToken(LoginMemberDto loginMemberDto)
        {
            var user = await _userManager.FindByEmailAsync(loginMemberDto.Email);
            if (user != null)
            {

                var result = await _signInManager.CheckPasswordSignInAsync
                                (user, loginMemberDto.Password, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    return null;
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, loginMemberDto.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken
                (
                    issuer: _config["Token:Issuer"],
                    audience: _config["Token:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey
                                (Encoding.UTF8.GetBytes(_config["Token:Key"])),
                            SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
        }
    }
}