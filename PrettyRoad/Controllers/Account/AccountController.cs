using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrettyRoad.BLL.Interface;
using PrettyRoad.JwtAuthenticationOptions;
using PrettyRoad.Models.Account;

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
    public async Task<IActionResult> SignInAsync(UserAuthenticationInfo authenticateInfo, CancellationToken cancellationToken = default)
    {
        var userAuthenticationDetails = await _userBLL.SignInAsync(authenticateInfo.Login, authenticateInfo.Password, cancellationToken);

        if (userAuthenticationDetails == null)
        {
            return BadRequest();
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
            AccessToken = encodedJwt,
            Username = userAuthenticationDetails.Login,
            ID = userAuthenticationDetails.ID
        };
        return Ok(response);
    }


    private ClaimsIdentity GetClaims(string login, Guid id)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim("ID", id.ToString())
            };

        var claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
    }
    
    
    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterModel registerModel, CancellationToken cancellationToken = default)
    {
        await _userBLL.RegisterAsync(registerModel.Login, registerModel.Password, cancellationToken);
        return Ok();
    }
}