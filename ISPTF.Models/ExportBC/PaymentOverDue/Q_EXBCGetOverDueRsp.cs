using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportBC
{
    public class Q_EXBCGetOverDueRsp

    {
        public DateTime? LastCalDate { get; set; }
        public DateTime? LastCalToDate { get; set; }
        public int? IntDay { get; set; }
        public double? BeforeDuePrin { get; set; }
        public double? BeforeDueInt { get; set; }

    }
}
