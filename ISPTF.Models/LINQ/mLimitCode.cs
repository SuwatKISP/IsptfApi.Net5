using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mLimitCode
    {
        public string Limit_Code { get; set; }
        public string Limit_Name { get; set; }
        public string Limit_UseFor { get; set; }
        public string Limit_UseCcy { get; set; }
        public string Limit_IMEX { get; set; }
        public string Limit_IMLC { get; set; }
        public string Limit_IMTR { get; set; }
        public string Limit_EXLC { get; set; }
        public string Limit_EXBC { get; set; }
        public string Limit_EXPC { get; set; }
        public string Limit_DLC { get; set; }
        public string Limit_IMP { get; set; }
        public string Limit_EXP { get; set; }
        public string Limit_LG { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
