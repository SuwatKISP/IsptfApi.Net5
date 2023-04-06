using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.MCampaign
{
    public class MCampaign
    {
        public string? Campaign_Code { get; set; }
        public string? Campaign_Name { get; set; }
        public string? Campaign_Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
