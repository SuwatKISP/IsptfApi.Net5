using ISPTF.Models.Account;
using System;

namespace ISPTF.Services
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUserIdentity user);
    }
}
