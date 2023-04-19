using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MLimitCode
    {
        public string LimitCode { get; set; }
        public string LimitName { get; set; }
        public string LimitUseFor { get; set; }
        public string LimitUseCcy { get; set; }
        public string LimitImex { get; set; }
        public string LimitImlc { get; set; }
        public string LimitImtr { get; set; }
        public string LimitExlc { get; set; }
        public string LimitExbc { get; set; }
        public string LimitExpc { get; set; }
        public string LimitDlc { get; set; }
        public string LimitImp { get; set; }
        public string LimitExp { get; set; }
        public string LimitLg { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
