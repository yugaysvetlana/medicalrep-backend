using MedicalPlatform.Application.Interfaces.Auth;
using MedicalPlatform.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlatform.Infrastructure
{
    public class JwtProvider(IOptions<JwtOptions> options): IJwtProvider
    {
        public readonly JwtOptions _options = options.Value;
     
        public string Generate(User user)
        {
            Claim[] claims =
            [
                new ("userId", user.Id.ToString()),
            ];
            var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours),
                signingCredentials: signingCredentials);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
