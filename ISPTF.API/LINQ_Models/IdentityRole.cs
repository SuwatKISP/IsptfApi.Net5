using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class IdentityRole
    {
        public IdentityRole()
        {
            IdentityUserRoles = new HashSet<IdentityUserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IdentityUserRole> IdentityUserRoles { get; set; }
    }
}
