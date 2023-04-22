using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class EXBCAcceptTermDueListPageResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXBCAcceptTermDueListPageRsp> Data { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public int TotalPage { get; set; }
    }
}
