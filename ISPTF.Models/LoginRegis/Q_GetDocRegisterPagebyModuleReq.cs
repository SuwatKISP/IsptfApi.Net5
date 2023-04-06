using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterPagebyModuleReq
    {
        //public string ScreenMenu { get; set; }
        public  string LogType { get; set; }
        public string CenterID { get; set; }
        public string RegDocNo { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
