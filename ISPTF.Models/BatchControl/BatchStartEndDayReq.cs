using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.BatchControl
{
    public class BatchStartEndDayReq
    {
        public DateTime? TodayDate { get; set; }
        public DateTime? NextDate { get; set; }
        public string UserCode { get; set; }
        public string DateFlag { get; set; }
    }
}
