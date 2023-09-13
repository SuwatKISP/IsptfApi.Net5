using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveIssue_ListType_req
    {
        public string? ListType {get; set;}
        public string? cutLineTextF50K { get; set; }
        public string? cutLineTextF59 { get; set; }
    }
}
