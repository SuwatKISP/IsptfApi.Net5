﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.BankFile
{
    public class MBankFileGetSwiftRsp
    {
        public int RCount { get; set; }
        public string Bank_Code { get; set; }
        public string Bank_SWIFT { get; set; }
    }
}

