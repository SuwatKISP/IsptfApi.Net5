using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.API
{
    public class Auth:IJwtAuth
    {
        private readonly string key;
        private readonly IConfiguration config;
        public Auth(string key, IConfiguration config)
        {
            this.key = key;
            this.config = config;
        }
        public string Authentication(string username, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name,username),
                        new Claim(ClaimTypes.Role,"Supervisor"),
                        new Claim(ClaimTypes.GivenName,"Test")
                    }),
                Expires = DateTime.UtcNow.AddHours(config.GetValue<int>("JwtToken:ExpiryHours")),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenResult = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(tokenResult);

        }
    }
}
