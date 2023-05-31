using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mMapAccount
    {
        public string mAcc_Code { get; set; }
        public string mAcc_New { get; set; }
        public string mAcc_Name { get; set; }
        public string mAcc_Type { get; set; }
        public string mAcc_BuArea { get; set; }
        public string mAcc_Cost { get; set; }
        public string mAcc_Profit { get; set; }
        public string mAcc_BsLine { get; set; }
        public string mAcc_Cond { get; set; }
        public string mAcc_Mod { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string GFMS_Map { get; set; }
        public string GFMS_Acc { get; set; }
        public string GFMS_SubAcc { get; set; }
        public string GFMS_Prod { get; set; }
        public string GFMS_Bran { get; set; }
        public string GFMS_SBU { get; set; }
    }
}
