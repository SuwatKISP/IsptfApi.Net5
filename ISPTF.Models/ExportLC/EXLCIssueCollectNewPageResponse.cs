using ISPTF.Models.ExportLC;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class EXLCIssueCollectNewPageResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCIssueNewPageRsp> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
