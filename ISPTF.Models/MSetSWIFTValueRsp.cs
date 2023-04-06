using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MSetSWIFTValueRsp
    {
        public string CenterCode { get; set; }
        public string Parameter { get; set; }
        public string DataValue { get; set; }
        public string SwiftAuto{get;set;}
        public int RCount { get; set; }

    }
}
