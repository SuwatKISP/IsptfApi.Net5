using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportLC.LCOverDueWREF
{
    public class EXLCLCOverDueWREFSelectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXLCRecordRsp Data { get; set; }
    }
}
