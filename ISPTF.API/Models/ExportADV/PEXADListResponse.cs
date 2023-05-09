using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportADV
{
    public class PEXADListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<pExad> Data { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public int TotalPage { get; set; }
    }
}
