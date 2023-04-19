using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MTitle
    {
        public string TitleCode { get; set; }
        public string TitleName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string TitleFlag { get; set; }
    }
}
