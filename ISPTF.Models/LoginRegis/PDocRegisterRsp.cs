using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class PDocRegisterRsp : PDocRegister
    {
        public DateTime UpdateDate { get; set; } 
        public DateTime AuthDate { get; set; } 

    }
}
