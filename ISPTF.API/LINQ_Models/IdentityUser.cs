using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class IdentityUser
    {
        public IdentityUser()
        {
            IdentityUserClaims = new HashSet<IdentityUserClaim>();
            IdentityUserLogins = new HashSet<IdentityUserLogin>();
            IdentityUserRoles = new HashSet<IdentityUserRole>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Username { get; set; }

        public virtual IdentityUserProfile IdentityUserProfile { get; set; }
        public virtual ICollection<IdentityUserClaim> IdentityUserClaims { get; set; }
        public virtual ICollection<IdentityUserLogin> IdentityUserLogins { get; set; }
        public virtual ICollection<IdentityUserRole> IdentityUserRoles { get; set; }
    }
}
