using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Constants;
using Domain.Models.Aurthenticated;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class JwtService
    {
        private const int EXPIRATION_MINUTES = 10;
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AuthenticatedResponse CreateToken(IdentityUser user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

            var token = CreateJwtToken(CreateClaims(user), CreateCredentials(), expiration);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new AuthenticatedResponse
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expiration
            };
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) 
        {
            return new JwtSecurityToken(
                _configuration[JwtBearerConstants.JWT_ISSUER],
                _configuration[JwtBearerConstants.Jwt_Audience],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }

        private Claim[] CreateClaims(IdentityUser user) 
        {
            return new Claim[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration[JwtBearerConstants.Jwt_Subject]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };
        }

        private SigningCredentials CreateCredentials() 
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[JwtBearerConstants.JWT_KEY])),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}