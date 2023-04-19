using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MTextFile
    {
        public string TextModule { get; set; }
        public string TextField { get; set; }
        public int TextNo { get; set; }
        public string TextCond { get; set; }
        public string TextData { get; set; }
    }
}
