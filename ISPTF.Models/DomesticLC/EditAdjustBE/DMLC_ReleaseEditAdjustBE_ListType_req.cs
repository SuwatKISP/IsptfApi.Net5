using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleaseEditAdjustBE_ListType_req
    {
        public string? LoadBL { get; set; }
        public DateTime? DmaskNewDate { get; set; }
        public DateTime? MaskNewDate { get; set; }
        public DateTime? MaskStartInt { get; set; }
    }
}
