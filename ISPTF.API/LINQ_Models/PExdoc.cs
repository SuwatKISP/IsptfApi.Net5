using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PExdoc
    {
        public string ExlcNo { get; set; }
        public int Seqno { get; set; }
        public int EventNo { get; set; }
        public string DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string FmailNo { get; set; }
        public string SmailNo { get; set; }
        public string ModuleType { get; set; }
        public DateTime? EventDate { get; set; }
        public string CenterId { get; set; }
    }
}
