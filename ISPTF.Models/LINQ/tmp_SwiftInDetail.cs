using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_SwiftInDetail
    {
        public string FileName { get; set; }
        public string SwiftInID { get; set; }
        public string SwiftInType { get; set; }
        public int RunLineNo { get; set; }
        public string Description { get; set; }
        public string FieldNo { get; set; }
        public DateTime? LoadDate { get; set; }
    }
}
