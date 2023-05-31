using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mBranch
    {
        public string Bran_Code { get; set; }
        public string Bran_Name { get; set; }
        public string Prov_Code { get; set; }
        public string Bran_GL { get; set; }
        public string Bran_BA { get; set; }
        public string Bran_Cost { get; set; }
        public string Bran_Profit { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string OnePUse { get; set; }
    }
}
