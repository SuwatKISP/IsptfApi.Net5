using ISPTF.Models.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.LINQ_Models.ExportBC
{
    public class EXBCIssuePurchaseNewSelectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<PDocRegister> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
