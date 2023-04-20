﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PClogLimit
    {
        public string LrecType { get; set; }
        public int LlogSeq { get; set; }
        public string LcustCode { get; set; }
        public string LfacilityNo { get; set; }
        public string LccsNo { get; set; }
        public string LlimitCode { get; set; }
        public int? LupdNo { get; set; }
        public string Lstatus { get; set; }
        public DateTime? LstartDate { get; set; }
        public DateTime? LexpiryDate { get; set; }
        public string LfacilityType { get; set; }
        public string LrevolFlag { get; set; }
        public string LshareFlag { get; set; }
        public string LshareType { get; set; }
        public string LcreditCcy { get; set; }
        public double? LcreditAmount { get; set; }
        public double? LcreditShare { get; set; }
        public string Lremark { get; set; }
        public string LblockCode { get; set; }
        public DateTime? LblockDate { get; set; }
        public string LblockNote { get; set; }
        public double? LholdAmount { get; set; }
        public double? LearAmount { get; set; }
        public string RecStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string LparentId { get; set; }
        public int? Lsseqno { get; set; }
        public string Lcondition { get; set; }
        public double? LoriginAmount { get; set; }
        public string Lcfrrate { get; set; }
        public double? Lcfrspread { get; set; }
        public double? Lcframount { get; set; }
        public string LcampaignCode { get; set; }
        public DateTime? LcampaignEffDate { get; set; }
    }
}