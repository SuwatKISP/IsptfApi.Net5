using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PControlPack

{
    public class PControlPack
    {
        public string? ContNo { get; set; }
        public DateTime? ContDate { get; set; }
        public string? ContTime { get; set; }
        public string? CustCode { get; set; }
        public string? CustInfo { get; set; }
        public string? CntyCode { get; set; }
        public string? AppName { get; set; }
        public string? GoodCode { get; set; }
        public string? RelCode { get; set; }
        public string? ShipmentFr { get; set; }
        public string? ShipmentTo { get; set; }
        public string? GoodDesc { get; set; }
        public string? PackUnder { get; set; }
        public string? ReferLcNo { get; set; }
        public string? DocCcy { get; set; }
        public double? DocAmount { get; set; }
        public double? DocBalance { get; set; }
        public double? UseAmount { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? Expirydate { get; set; }
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
        public string? UserCode { get; set; }
        public string? ContStatus { get; set; }
        public string? InUser { get; set; }
        public string? CenterID { get; set; }

    }
}
