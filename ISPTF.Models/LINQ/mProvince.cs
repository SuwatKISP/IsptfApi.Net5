using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mProvince
    {
        public string Prov_Code { get; set; }
        public string Prov_Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
