using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MNostroGl
    {
        public string NostroBank { get; set; }
        public string NostroCcy { get; set; }
        public string NostroGl { get; set; }
        public string RecStatus { get; set; }
        public string PayNote { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
