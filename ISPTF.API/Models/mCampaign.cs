using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mCampaign
    {
        public string Campaign_Code { get; set; }
        public string Campaign_Name { get; set; }
        public string Campaign_Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
