using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.InUse

{
    public class UpdateInUseReq
    {

        public string? Module { get; set; }
        public string? Function { get; set; }
        public string? DocNumber { get; set; }
        public int? EventNo { get; set; }
        public string? InUse { get; set; }

    }
}
