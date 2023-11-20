using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleaseIssueForm_UpdateAmend_req
    {
        //public DateTime? EventDate { get; set; }                //public DateTime? MaskEvent { get; set; }
        //public int? AmendSeq { get; set; }                      //public int? TxAmendSeq { get; set; }
        //public DateTime? DateExpiry { get; set; }               //public DateTime? MaskExpiry { get; set; }
        //public string? TenorType { get; set; }                  //public string? CmbTenor { get; set; }
        //public int? TenorDay { get; set; }                      //public int? TxTenorDay { get; set; }
        //public string? TenorTerm { get; set; }                  //public string? CmbTerm { get; set; }
        //public string? BenCode { get; set; }                     //public string? TxBen { get; set; }
        //public string? BenInfo { get; set; }                    //public string? TxBenAddr { get; set; }
        //public string? OldBenCode { get; set; }
        //public string? OldBenInfo { get; set; }
        //public DateTime? DateLateShip { get; set; }             //public DateTime? MaskShip { get; set; }
        //public int? PresentDay { get; set; }                    //public int? TxPreDay { get; set; }
        //public string? PartialShipment { get; set; }            //public string? OpPartYes { get; set; }
        //public string? TranShipment { get; set; }               //public string? OpTransyes { get; set; }
        //public string? GoodsCode { get; set; }                  //public string? TxGoods { get; set; }
        //public string? PurposeCode { get; set; }                //public string? LbPurCode { get; set; }
        //public string? GoodsDesc { get; set; }                  //public string? TxGoods01 { get; set; }
        //public double? CommLCRate { get; set; }                 //public double? TxCommRate { get; set; }
        //public string? TaxRefund { get; set; }                  //public string? OpTaxYes { get; set; }
        //public double? TaxAmt { get; set; }                     //public double? TxTaxAmt { get; set; }
        //public string? PayFlag { get; set; }                    //public string? OpPaid { get; set; } 
        //public string? PayMethod { get; set; }                  //public string? CmbPayment { get; set; }
        //public double? CommAmt { get; set; }                    //public double? TxCommAmt { get; set; }
        //public double? DutyStamp { get; set; }                  //public double? TxDutyAmt { get; set; }
        //public double? PayableStamp { get; set; }               //public double? TxPayable { get; set; }
        //public double? OthCharge { get; set; }                  //public double? TxOthAmt { get; set; }



        public DateTime? MaskEvent { get; set; }
        public int? TxAmendSeq { get; set; }
        public DateTime? MaskExpiry { get; set; }
        public string? CmbTenor { get; set; }
        public int? TxTenorDay { get; set; }
        public string? CmbTerm { get; set; }
        public string? TxBen { get; set; }
        public string? TxBenAddr { get; set; }
        public string? OldBenCode { get; set; }
        public string? OldBenInfo { get; set; }
        public DateTime? MaskShip { get; set; }
        public int? TxPreDay { get; set; }
        public string? OpPartYes { get; set; }
        public string? OpTransyes { get; set; }
        public string? TxGoods { get; set; }
        public string? LbPurCode { get; set; }
        public string? TxGoods01 { get; set; }
        public double? TxCommRate { get; set; }
        public string? OpTaxYes { get; set; }
        public double? TxTaxAmt { get; set; }
        public string? OpPaid { get; set; }
        public string? CmbPayment { get; set; }
        public double? TxCommAmt { get; set; }
        public double? TxDutyAmt { get; set; }
        public double? TxPayable { get; set; }
        public double? TxOthAmt { get; set; }

    }
}
