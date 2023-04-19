using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class IdentityUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public int UserId { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}
