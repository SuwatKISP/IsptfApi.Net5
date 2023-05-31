using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class CustRelateISP
    {
        public string CIFNo { get; set; }
        public string Filler { get; set; }
        public string BaseName { get; set; }
        public string RootName { get; set; }
        public string RootRefNo { get; set; }
        public string TransStatus { get; set; }
        public string RelatNo { get; set; }
        public string RelatSystem { get; set; }
        public string AddDate { get; set; }
        public string LastMaDate { get; set; }
        public string LastMaUser { get; set; }
        public string Status { get; set; }
        public string Spare { get; set; }
        public string AsAtDate { get; set; }
        public string RunDate { get; set; }
        public string RunTime { get; set; }
        public string EndRec { get; set; }
        public string UDATA_TM { get; set; }
        public string UDATA_DT { get; set; }
    }
}
