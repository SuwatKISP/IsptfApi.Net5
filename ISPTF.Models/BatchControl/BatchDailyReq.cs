using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.BatchControl
{
    public class BatchDailyReq
    {
        public DateTime? RunBatchDate { get; set; }
        public string RerunGFMS { get; set; }
    }
}
