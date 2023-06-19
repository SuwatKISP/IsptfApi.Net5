using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class PDocRegisterInsUpdReq : PDocRegister
    {
        //public string ScreenMenu { get; set; }
        public string logType { get; set; }
        public PDocRegInv[] DocRegInv { get; set; }

    }
}
