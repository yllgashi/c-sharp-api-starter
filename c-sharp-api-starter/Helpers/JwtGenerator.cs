using Microsoft.IdentityModel.Tokens;
using models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace c_sharp_api_starter.Helpers
{
    public class JwtGenerator
    {

        public string GenerateToken(int id, string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.AuthorizationSecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[] { new Claim("UserId", id.ToString(), ClaimValueTypes.Integer), new Claim("Email", email) };

            var token = new JwtSecurityToken(
              AppSettings.AuthorizationIssuer,
              AppSettings.AuthorizationAudience,
              claims: claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
