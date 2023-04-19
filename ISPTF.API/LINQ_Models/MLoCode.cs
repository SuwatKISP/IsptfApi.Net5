using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MLoCode
    {
        public string LoCode { get; set; }
        public string LoName { get; set; }
        public string LoRcCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
