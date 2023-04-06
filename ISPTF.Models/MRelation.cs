using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MRelation
    {
        public string rel_Code { get; set; }
        public string rel_Desc { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public string userCode { get; set; }
    }
}
