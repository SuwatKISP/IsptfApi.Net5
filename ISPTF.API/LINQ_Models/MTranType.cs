﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MTranType
    {
        public string TranCode { get; set; }
        public string TranDesc { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
