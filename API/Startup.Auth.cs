using Api.Provider;
using Application.Contract;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public partial class Startup
    {
        private static readonly string secretKey = "d71a5f83-8132-4c50-acd0-96ed6ebbf61d";

        private void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();

            var signingKey = new SymmetricSecurityKey(ASCIIEncoding.ASCII.GetBytes(secretKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = "Issuer",
                ValidateAudience = true,
                ValidAudience = "Audience",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            app.UseSimpleTokenProvider(new TokenProviderOptions
            {
                Path = "/token",
                RefreshPath = "/refresh-token",
                Audience = "Audience",
                Issuer = "Issuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = GetIdentity,
                TokenKey = Configuration.GetValue<string>("Api:TokenKey")
            }, tokenValidationParameters);
        }

        private Task<User> GetIdentity(IUserApplication userApplication, string username, string password)
        {
            User user = userApplication.Authenticate(username, password);

            if (user == null)
                return Task.FromResult<User>(null);

            return Task.FromResult(user);
        }
    }
}
