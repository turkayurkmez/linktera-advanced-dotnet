using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost]
        public IActionResult Login(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.UserName == "admin" && viewModel.Password == "123")
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-ifade-tokeni-kanitlar"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName,"turkay"),
                        new Claim(ClaimTypes.Role,"admin")
                    };

                    var token = new JwtSecurityToken(
                        issuer: "server.linktera",
                        audience: "client.linktera",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(7),
                        signingCredentials: credential
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                ModelState.AddModelError("fail", "Kullanıcı bilgileri yanlış");
            }

            return BadRequest(ModelState);
        }
    }
}
