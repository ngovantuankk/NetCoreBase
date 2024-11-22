using NetCoreBase.Application.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace NetCoreBase.Infrastructure.Authentication;

public class JwtGenerator : IJwtGenerator
{
    public string GenerateJwt(Guid id, string firstName, string lastName, string address)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("key-secret-keyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy")),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: "Tuan Ngo",
            audience: "Tuan KK",
            expires: DateTime.Now.AddMinutes(120),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}