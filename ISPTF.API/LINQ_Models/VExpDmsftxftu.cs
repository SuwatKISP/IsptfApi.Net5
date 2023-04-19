using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class VExpDmsftxftu
    {
        public string RefNumber { get; set; }
        public string EventType { get; set; }
        public DateTime? EventDate { get; set; }
        public string BeneId { get; set; }
        public string AppName { get; set; }
        public string DraftCcy { get; set; }
        public double? AmtCcy { get; set; }
        public double? ExchRate { get; set; }
        public double? AmtThb { get; set; }
        public string ForwardCont { get; set; }
    }
}
