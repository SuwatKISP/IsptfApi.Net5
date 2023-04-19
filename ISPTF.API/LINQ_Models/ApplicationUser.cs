using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        public string Username { get; set; }
        public string NormalizedUsername { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Fullname { get; set; }
        public string PasswordHash { get; set; }
    }
}
