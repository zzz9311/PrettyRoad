using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrettyRoad.BLL.Interface;
using PrettyRoad.JwtAuthenticationOptions;

namespace PrettyRoad.Controllers.Account;

[Authorize]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IUserBLL _userBLL;
    public AccountController(IUserBLL userBll)
    {
        _userBLL = userBll;
    }
    
    [HttpPost("SignIn")]
    [AllowAnonymous]
    public async Task<IActionResult> SignInAsync(CancellationToken cancellationToken = default)
    {
        var userAuthenticationDetails = await _userBLL.SignInAsync("Tets", "textt", cancellationToken);

        if (userAuthenticationDetails == null)
        {
            return Ok(); //TODO throw something
        }
        
        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: JwtOptions.Issuer,
            audience: JwtOptions.Audience,
            notBefore: now,
            claims: GetClaims(userAuthenticationDetails.Login, userAuthenticationDetails.ID).Claims,
            expires: now.Add(TimeSpan.FromMinutes(JwtOptions.TokenLifeTime)),
            signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        
        var response = new
        {
            access_token = encodedJwt,
            username = userAuthenticationDetails.Login,
            ID = userAuthenticationDetails.ID
        };
        return Ok(response);
    }


    private ClaimsIdentity GetClaims(string login, Guid id)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim("id", id.ToString())
            };
        
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            
            return claimsIdentity;
    }
    
    
    public class RegisterModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel registerModel, CancellationToken cancellationToken = default)
    {
        await _userBLL.RegisterAsync(registerModel.Login, registerModel.Password, cancellationToken);
        return Ok();
    }
}