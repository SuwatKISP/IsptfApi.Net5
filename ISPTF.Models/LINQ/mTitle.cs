using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mTitle
    {
        public string Title_Code { get; set; }
        public string Title_Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string Title_flag { get; set; }
    }
}
