using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MAccount
    {
        public string acc_Code { get; set; }
        public string acc_Name { get; set; }
        public string acc_Map { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public string userCode { get; set; }
        public string acc_GFMS { get; set; }
        public string acc_GFMS_Sub { get; set; }
        public string gfmS_Map { get; set; }
        public string gfmS_Prod { get; set; }
        public string gfmS_Bran { get; set; }
        public string gfmS_SBU { get; set; }
        public string acc_Flag { get; set; } 
    }
}
