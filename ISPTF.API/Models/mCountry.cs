using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mCountry
    {
        public string Cnty_Code { get; set; }
        public string Cnty_Name { get; set; }
        public string Cnty_Area { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
