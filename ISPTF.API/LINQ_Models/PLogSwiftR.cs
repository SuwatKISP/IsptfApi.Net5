using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PLogSwiftR
    {
        public string FileName { get; set; }
        public DateTime FileDate { get; set; }
        public DateTime? LoadDate { get; set; }
        public string LoadStatus { get; set; }
    }
}
