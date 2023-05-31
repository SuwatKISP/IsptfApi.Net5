using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mNostroGL
    {
        public string Nostro_Bank { get; set; }
        public string Nostro_Ccy { get; set; }
        public string Nostro_GL { get; set; }
        public string RecStatus { get; set; }
        public string PayNote { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
