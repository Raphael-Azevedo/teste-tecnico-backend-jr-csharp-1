using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProPet.Services.Interfaces;

namespace ProPet.Services;

public class TokenServices(IConfiguration configurations) : ITokenServices
{
    private readonly IConfiguration _configuration = configurations;

    public string GenerateToken(int userId, string userName, string role)
    {
        var claims = new[]
        {
            new Claim("userId", userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, userName),
            new Claim(ClaimTypes.Role, role)
        };

        var secret = _configuration.GetSection("JwtSettings").GetValue<string>("Secret");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = "",
            Issuer = "",
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = creds
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}