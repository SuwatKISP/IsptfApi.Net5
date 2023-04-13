using ISPTF.Models.ExportLC;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class EXLCAcceptTermDueListPageRespond
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCAcceptTermDueListPageRsp> Data { get; set; }
    }
}
