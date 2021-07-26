using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Pointer.Presentation.Api.Managers
{
    public class TokenManager
    {
        public JwtSecurityTokenHandler TokenHandler { get; } = new JwtSecurityTokenHandler();

        public SecurityKey IssuerKey { get; set; }

        public string Issuer { get; set; }

        public TokenManager(IConfiguration configuration)
        {
            IssuerKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            Issuer = configuration["JWT:Issuer"];
        }

        public void AddJwt(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = IssuerKey,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = Issuer,
                    ValidateLifetime = true
                };
            });
        }

        public string Generate(string sub)
        {
            var token = new JwtSecurityToken(Issuer, claims: new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, sub.ToString())
            }, expires: DateTime.UtcNow.AddDays(14), signingCredentials: new SigningCredentials(IssuerKey, SecurityAlgorithms.HmacSha256));
            return TokenHandler.WriteToken(token);
        }
    }
}