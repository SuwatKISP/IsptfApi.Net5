﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PLogSwiftInFile
    {
        public string FileName { get; set; }
        public DateTime FileDate { get; set; }
        public DateTime? LoadDate { get; set; }
        public string LoadStatus { get; set; }
    }
}