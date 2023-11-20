using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.BatchControl
{
    public class BTBatchLogQuery
    {
        public DateTime? RunDate { get; set; }
        public string? StartTime { get; set; }
        public string? LastTime { get; set; }
        public int? JobNo { get; set; }
        public string? JobName { get; set; }
        public string? RunStat { get; set; }


    }
}

