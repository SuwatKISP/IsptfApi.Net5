using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PSwimpText
    {
        public string Login { get; set; }
        public string DocNumber { get; set; }
        public int Seqno { get; set; }
        public string Mtno { get; set; }
        public string Fdno { get; set; }
        public string TextData { get; set; }
    }
}
