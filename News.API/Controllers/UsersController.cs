using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using News.BL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace News.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public UsersController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<TokenDTO> Login(LoginDTO loginDTO)
        {
            if (loginDTO.UserName != "admin" || loginDTO.Password != "admin")
            {
                return BadRequest();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,"admin")
            };

            string? keyString = configuration.GetValue<string>("SecretKey");
            byte[] keyBytes = Encoding.ASCII.GetBytes(keyString!);
            var key = new SymmetricSecurityKey(keyBytes);

            var credetianls = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            DateTime exp = DateTime.Now.AddMinutes(30);

            var newToken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credetianls,
                expires: exp
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(newToken);

            return new TokenDTO { Token = token };
        }
    }
}
