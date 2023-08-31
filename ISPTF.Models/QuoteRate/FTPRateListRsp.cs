using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class FTPRateListRsp
    {
        //Rate_Type, CurCode, TermType, Rate, RateDate, Delete_Flag, Load_Flag, ZZStrdate, ZZdate, ZZUser, FileName
        public DateTime? RateDate { get; set; }
        public string? Rate_Type { get; set; }
        public string? CurCode { get; set; }
        public string? TermType { get; set; }
        public double? Rate { get; set; }
        public string? ZZUser { get; set; }
        public string? Load_Flag { get; set; }
        public string? FileName { get; set; }
        public int rCount { get; set; }

    }
}
