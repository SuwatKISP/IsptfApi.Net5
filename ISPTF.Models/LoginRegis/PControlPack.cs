using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class PControlPack
    {
        public string ContNo { get; set; }
        public string ContDate { get; set; }
        public string ContTime { get; set; }
        public string CustCode { get; set; }
        public string CustInfo { get; set; }
        public string CntyCode { get; set; }
        public string AppName { get; set; }
        public string GoodCode { get; set; }
        public string RelCode { get; set; }
        public string ShipmentFr { get; set; }
        public string ShipmentTo { get; set; }
        public string GoodDesc { get; set; }
        public string PackUnder { get; set; }
        public string ReferLcNo { get; set; }
        public string DocCcy { get; set; }
        public string DocAmount { get; set; }
        public string DocBalance { get; set; }
        public string UseAmount { get; set; }
        public string IssueDate { get; set; }
        public string Expirydate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string UserCode { get; set; }
        public string ContStatus { get; set; }
        public string InUser { get; set; }
        public string CenterID { get; set; }

    }
}
