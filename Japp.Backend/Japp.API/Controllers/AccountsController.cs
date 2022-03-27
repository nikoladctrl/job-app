using System.Threading.Tasks;
using Japp.BusinessLayer.Services.Accounts;
using Japp.Core.DTOs.Accounts;
using Japp.Core.DTOs.Member;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Japp.API.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;            
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterMemberDto registerMemberDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Register(registerMemberDto);
                if (result is IdentityResult) 
                {
                    IdentityResult ir = (IdentityResult) result;
                    return BadRequest(ir.Errors);
                }
                return Ok(result);
            }
            return BadRequest("Fill all required fields.");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginMemberDto loginMemberDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(loginMemberDto);
                if (result.GetType() == typeof(RegisteredMemberDto)) {
                    return Ok(result);
                }
                return BadRequest("Something went wrong. Please try again!");
            }
            return BadRequest("Please fill all necessary fields.");
        }
    }

// {
//   "email": "nikolaradanovic@test.com",
//   "password": "Nikola!1",
//   "confirmPassword": "Nikola!1",
//   "firstName": "Nikola",
//   "lastName": "Radanovic",
//   "userName": "nikolaradanovic",
//   "isAdmin": true
// }

// {
//   "email": "dusan@bayrock.com",
//   "password": "Dusan123!",
//   "confirmPassword": "Dusan123!",
//   "firstName": "Dusan",
//   "lastName": "Boljanic",
//   "userName": "dusanb",
//   "knownAs": "dule",
//   "isAdmin": false
// }
}