using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using WebApplicationDemo.Repository;

namespace WebApplicationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate()
        {

            List<Claim> claims = new List<Claim> {
                new Claim("role","admin")
            };

            DateTime expiresAt = DateTime.UtcNow.AddHours(10);

            return Ok(new
            {
                accessToken = CreateToken(claims, expiresAt),
                expires = expiresAt              
            });
            

        }

        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            byte[] secretKey = Encoding.ASCII.GetBytes(_configuration["SecretKey"] ?? string.Empty);

            //generate the jwt
            JwtSecurityToken jwt = new JwtSecurityToken(
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: expiresAt,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(secretKey),
                        SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
