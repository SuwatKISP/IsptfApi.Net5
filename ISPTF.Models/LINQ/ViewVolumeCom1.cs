﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewVolumeCom1
    {
        public DateTime VouchDate { get; set; }
        public string Keynumber { get; set; }
        public string TranAccount { get; set; }
        public string TranCcy { get; set; }
        public string TranNature { get; set; }
        public double? TranExch { get; set; }
        public double? Amount { get; set; }
        public string TranDesc { get; set; }
        public string TranMod { get; set; }
        public string TranDept { get; set; }
        public string TranStatus { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string SendFlag { get; set; }
        public int? Tenor_Type { get; set; }
        public string CenterID { get; set; }
        public int TranDocSeq { get; set; }
    }
}
