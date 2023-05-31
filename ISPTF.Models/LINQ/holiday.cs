using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class holiday
    {
        public string Hol_Year { get; set; }
        public string Hol_Date { get; set; }
        public string Hol_Desc { get; set; }
        public string Hol_RecStat { get; set; }
        public string UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
