using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveIssueForm_JSON_rsp
    {
        public Q_DMLC_Issue_Select_pDOMLC_rsp pDOMLC { get; set; }
        public Q_DMLC_Issue_Select_pPayment_rsp pPayment { get; set; }
    }
}
