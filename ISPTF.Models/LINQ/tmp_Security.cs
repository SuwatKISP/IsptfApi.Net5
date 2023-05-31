using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_Security
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}
