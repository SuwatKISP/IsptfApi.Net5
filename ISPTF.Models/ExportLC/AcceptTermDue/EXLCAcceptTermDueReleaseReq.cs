using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportLC
{
    public class EXLCAcceptTermDueReleaseReq
	{
		public string? EXPORT_LC_NO { get; set; }
		public int? EVENT_NO { get; set; }
		public string? RECORD_TYPE { get; set; }
		public string? REC_STATUS { get; set; }
	}
}
