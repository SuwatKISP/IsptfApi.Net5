using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MAccount
    {
        public string AccCode { get; set; }
        public string AccName { get; set; }
        public string AccMap { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string AccGfms { get; set; }
        public string AccGfmsSub { get; set; }
        public string GfmsMap { get; set; }
        public string GfmsProd { get; set; }
        public string GfmsBran { get; set; }
        public string GfmsSbu { get; set; }
        public string AccFlag { get; set; }
    }
}
