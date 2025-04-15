using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProximaEnergia.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace ProximaEnergia.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;
        public async Task<string> GetToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("api-key").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, "davidvirtus"),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("issuer").Value,
                audience: _configuration.GetSection("audience").Value,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
