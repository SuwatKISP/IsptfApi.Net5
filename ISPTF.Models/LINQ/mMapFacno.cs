using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mMapFacNo
    {
        public string Cust_Code { get; set; }
        public string FacNo { get; set; }
        public string Purpose_Code { get; set; }
        public string ISIC_Code { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
