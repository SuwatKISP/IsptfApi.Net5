﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PSendLcmail
    {
        public DateTime SendDate { get; set; }
        public string AccessId { get; set; }
        public string LcNumber { get; set; }
        public string CustCode { get; set; }
        public string Status { get; set; }
    }
}