using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class IdentityUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual IdentityRole Role { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
