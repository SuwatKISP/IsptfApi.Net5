using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.GetAny
{
    public class CheckGLBalanceReq
    {
        public DateTime? VourchDate { get; set; }
        public string? VourchID{ get; set; }
    }
}
