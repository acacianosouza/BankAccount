using System;
using System.Threading.Tasks;
using Application.Contract;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Api.Provider
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/token";
        public string RefreshPath { get; set; } = "/refresh-token";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(15);
        public TimeSpan ExpirationMobile { get; set; } = TimeSpan.FromDays(30);
        public SigningCredentials SigningCredentials { get; set; }
        public Func<IUserApplication, string, string, Task<User>> IdentityResolver { get; set; }
        public Func<Task<string>> NonceGenerator { get; set; }
            = new Func<Task<string>>(() => Task.FromResult(Guid.NewGuid().ToString()));
        public string TokenKey { get; internal set; }
    }
}