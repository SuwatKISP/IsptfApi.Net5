using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpSecurity
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}
