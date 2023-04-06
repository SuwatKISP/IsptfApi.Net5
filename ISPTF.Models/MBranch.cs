using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MBranch
    {
        public string bran_Code { get; set; }
        public string bran_Name { get; set; }
        public string prov_Code { get; set; }
        public string bran_GL { get; set; }
        public string bran_BA { get; set; }
        public string bran_Cost { get; set; }
        public string bran_Profit { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }
        public string userCode { get; set; }
        public string onePUse { get; set; }
    }
}
