using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MTitle
    {
        public string title_Code { get; set; }
        public string title_Name { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public string userCode { get; set; }
        public string title_Flag { get; set; }
    }
}
