using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class FTPRateSelectRsp
    {
        //RateDate, Rate_Type, CurCode, TermType, Rate, Delete_Flag, Load_Flag, ZZStrdate, ZZdate, ZZUser, FileName
        public DateTime? RateDate { get; set; }
        public string? Rate_Type { get; set; }
        public string? CurCode { get; set; }
        public string? TermType { get; set; }
        public double? Rate { get; set; }
        public string? Delete_Flag { get; set; }
        public string? Load_Flag { get; set; }
        public DateTime? ZZStrdate { get; set; }
        public DateTime? ZZdate { get; set; }
        public string? ZZUser { get; set; }
        public string? FileName { get; set; }

    }
}
