using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MCountry
    {
        public string cnty_Code { get; set; }
        public string cnty_Name { get; set; }
        public string cnty_Area { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public string userCode { get; set; }
    }
}
