using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_DeleteEditAdjustBE_pDOMBE_req
	{
		public string? BENumber { get; set; }
		public int? BESeqno { get; set; }
		public string? UserCode { get; set; }
		public string? CenterID { get; set; }
	}
}
