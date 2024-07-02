using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Gabfest.Services;

public static class JWTHelper
{
    public static string GenerateJWT(TokenModel tokenModel)
    {
        var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, tokenModel.Username),
            new Claim(ClaimTypes.Role, tokenModel.Role)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenModel.SignInKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: tokenModel.Issuer,
            audience: tokenModel.Audience,
            claims: claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials,
            notBefore: DateTime.Now
        );
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return token;
    }
}
