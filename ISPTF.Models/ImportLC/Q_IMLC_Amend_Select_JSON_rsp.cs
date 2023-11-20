using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_Amend_Select_JSON_rsp
    {
        public Q_IMLC_Amend_Select_pIMLC_rsp pIMLC { get; set; }
        public Q_IMLC_Amend_Select_SearchCust_rsp SearchCust { get; set; }
        public Q_IMLC_Amend_Select_SomeMasterData_rsp SomeMasterData { get; set; }
        public Q_IMLC_Amend_Select_pPayment_rsp pPayment { get; set; }
        public Q_IMLC_Amend_Select_mTextFile_rsp mTextFile { get; set; }
        public Q_IMLC_Amend_Select_pSWIMLC_rsp pSWIMLC_ASLCSeqno { get; set; }
        public Q_IMLC_Amend_Select_pSWIMLC_rsp pSWIMLC_ASSEQ2 { get; set; }
        public Q_IMLC_Amend_Select_pIMLCAmend_rsp pIMLCAmend { get; set; }
        public Q_IMLC_Amend_Select_pIMLCGoods_rsp pIMLCGoods { get; set; }
        public Q_IMLC_Amend_Select_DefaultCommRate_rsp DefaultCommRate { get; set; }

    }
}
