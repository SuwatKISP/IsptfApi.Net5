﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PEXDoc;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCCoveringLetterReleaseReq
    {
        public string EXPORT_BC_NO { get; set; }
        public int EVENT_NO { get; set; }
        public string USER_ID { get; set; }
        public string CenterID { get; set; }
        public PEXDOCRsp[] PEXDOC { get; set; }


    }
}
