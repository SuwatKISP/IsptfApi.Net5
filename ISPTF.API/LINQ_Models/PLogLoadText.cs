using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PLogLoadText
    {
        public string LoadDate { get; set; }
        public string BatchName { get; set; }
        public string Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
