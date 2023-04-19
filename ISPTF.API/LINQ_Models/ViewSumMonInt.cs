using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewSumMonInt
    {
        public string DocMonth { get; set; }
        public string CenterId { get; set; }
        public string DocCust { get; set; }
        public string Login { get; set; }
        public double? IntThb { get; set; }
        public string SendFlag { get; set; }
        public DateTime? CalDate { get; set; }
        public string DebitAcc { get; set; }
        public string UpReceipt { get; set; }
        public string UpFlag { get; set; }
        public string BatchType { get; set; }
        public int? RoundNo { get; set; }
    }
}
