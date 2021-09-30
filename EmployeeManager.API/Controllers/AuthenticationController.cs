using EmployeeManager.Common;
using EmployeeManager.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser<int>> userManager;
        private readonly SignInManager<IdentityUser<int>> signInManager;
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _confiuration;
        public AuthenticationController(
            UserManager<IdentityUser<int>> userManager,
            RoleManager<IdentityRole<int>>roleManager, 
            SignInManager<IdentityUser<int>> signInManager,
            IEmployeeService employeeService,
            IConfiguration confiuration)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this._employeeService = employeeService;
            _confiuration = confiuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.username);
            if(user!=null && await userManager.CheckPasswordAsync(user, model.password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var employee = await _employeeService.Get(new Infrastructure.Requests.EmployeeSearchRequest { UserID = user.Id });
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // id trenutno prijavljenog user-a
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                // SymmetricSecurityKey je niz bytova    da bi niz bytova pretvorili u string koristimo Encoding.UTF8.GetBytes
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confiuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _confiuration["JWT:ValidIssuer"],
                    audience: _confiuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)  // algoritam
                    );
                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration=token.ValidTo,
                    User=user.UserName,
                    Employee = employee.FirstOrDefault()
                });
            }
            return Unauthorized();
        }
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return Ok();
        //}
    }
}
