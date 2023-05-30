using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pHoliday
    {
        public string Hol_Year { get; set; }
        public DateTime Hol_Date { get; set; }
        public string Hol_Desc { get; set; }
        public string Hol_RecStat { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
