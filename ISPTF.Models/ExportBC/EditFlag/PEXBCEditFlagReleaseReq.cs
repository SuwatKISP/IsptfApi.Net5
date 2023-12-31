﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCEditFlagReleaseReq
    {
        public string EXPORT_BC_NO { get; set; }
        public string BENE_ID { get; set; }
        public string USER_ID { get; set; }
        public string CenterID { get; set; }
        public string EVENT_DATE { get; set; }
        public string VOUCH_ID { get; set; }
        public string AUTOOVERDUE { get; set; }
        public string INTFLAG { get; set; }
        public int OBASEDAY { get; set; }
        public string INTCODE { get; set; }
        public float OINTRATE { get; set; }
        public float OINTSPDRATE { get; set; }
        public float OINTCURRATE { get; set; }
    }
}
