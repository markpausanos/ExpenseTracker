using ExpenseTracker.Application.Common.Interfaces.Authentication;
using ExpenseTracker.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracker.Infrastructure.Authentication
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JWTTokenGenerator(IOptions<JWTSettings> jwtSettings, IDateTimeProvider dateTimeProvider)
        {
            _jwtSettings = jwtSettings.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddHours(_jwtSettings.ExpiryInMinutes),
                claims: claims,
                signingCredentials: signingCredentials);


            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
