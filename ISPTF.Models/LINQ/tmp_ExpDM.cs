using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_ExpDM
    {
        public string RefNumber { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventType { get; set; }
        public string BeneID { get; set; }
        public string AppName { get; set; }
        public string DraftCcy { get; set; }
        public double? AmtCcy { get; set; }
        public double? ExchRate { get; set; }
        public double? AmtTHB { get; set; }
        public string Forward { get; set; }
        public string FlagAmt { get; set; }
    }
}
