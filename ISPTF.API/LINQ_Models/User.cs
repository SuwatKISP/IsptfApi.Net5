using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class User
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
    }
}
