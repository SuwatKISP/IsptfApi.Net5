﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportLC
{
   public class PEXLCPPaymentSelectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXLCPPaymentDataContainer Data { get; set; }
    }
}
