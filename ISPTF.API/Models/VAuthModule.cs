using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class VAuthModule
    {
        public string UserID { get; set; }
        public string ModCode { get; set; }
        public string CTL_Type { get; set; }
        public string CTL_Name { get; set; }
        public string CTL_Desc { get; set; }
        public string CTL_Note1 { get; set; }
    }
}
