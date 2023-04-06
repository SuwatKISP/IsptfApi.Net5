using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MCustomer
    {
        [Required(ErrorMessage = "Purpose  Code is required")]
        //[Range(10, 10, ErrorMessage = "Limit Code must be 10 character")]
        [StringLength(6)]
        public string Cust_Code { get; set; }
        [StringLength(1)]
        public string? RecStatus { get; set; }
        [StringLength(1)]
        public string? Cust_Status { get; set; }
        [StringLength(9)]
        public string? Cust_CCID { get; set; }
        [StringLength(20)]
        public string? Cust_CIF { get; set; }
        [StringLength(8)]
        public string? Cust_T24 { get; set; }
        [StringLength(9)]
        public string? CNUM { get; set; }
        [StringLength(14)]
        public string? CCS_REF { get; set; }
        [StringLength(3)]
        public string? Cust_Title { get; set; }
        [StringLength(70)]
        public string? Cust_Name { get; set; }
        [StringLength(70)]
        public string? Cust_LastName { get; set; }
        [StringLength(3)]
        public string? Cust_TTitle { get; set; }
        [StringLength(70)]
        public string? Cust_TName { get; set; }
        [StringLength(70)]
        public string? Cust_TLastName { get; set; }
        [StringLength(1)]
        public string? Cust_Type { get; set; }
        [StringLength(2)]
        public string? Cust_Nation { get; set; }
        [StringLength(1)]
        public string? Cust_Group { get; set; }
        [StringLength(6)]
        public string? Cust_Parent { get;set;}
        [StringLength(4)]
        public string? Cust_Bran { get; set; }
        [StringLength(4)]
        public string? Cust_Rating { get; set; }
        [StringLength(8)]
        public string? Cust_Lo { get; set; }
        [StringLength(5)]
        public string? Cust_Ao { get; set; }
        [StringLength(1)]
        public string? Cust_BOI { get; set; }
        [StringLength(6)]
        public string? Cust_CsType { get; set; }
        [StringLength(7)]
        public string? Cust_BuType { get; set; }
        [StringLength(1)]
        public string? Cust_Size { get; set; }
        [StringLength(10)]
        public string? IRateTHB { get; set; }
        [StringLength(10)]
        public string? IRateCcy { get; set; }
        [StringLength(1)]
        public string? IRateFlag { get; set; }
        public DateTime? Cust_EntDate { get; set; } = DateTime.Now;
        [StringLength(13)]
        public string? Cust_RegistID { get; set; }
        public DateTime? Cust_RegistDate { get; set; } = DateTime.Now;
        [StringLength(13)]
        public string? Cust_TaxID { get; set; }
        [StringLength(50)]
        public string? Cust_Contact { get; set; }
        [StringLength(200)]
        public string? Cust_Remark { get; set; }
        [StringLength(35)]
        public string? Cust_Add1_Line1 { get; set; }
        [StringLength(35)]
        public string? Cust_Add1_Line2 { get; set; }
        [StringLength(35)]
        public string? Cust_Add1_Line3 { get; set; }
        [StringLength(35)]
        public string? Cust_Add1_Line4 { get; set; }
        [StringLength(5)]
        public string? Cust_Add1_Prov { get; set; }
        [StringLength(2)]
        public string? Cust_Add1_Cnty { get; set; }
        //[DataType(DataType.PhoneNumber)]
        //[Phone]
        [StringLength(20)]
        public string? Cust_Add1_Telno { get; set; }
        //[Phone]
        [StringLength(20)]
        public string? Cust_Add1_Faxno { get; set; }
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        [StringLength(300)]
        public string? Cust_Add1_Email { get; set; }
        [StringLength(35)]
        public string? Cust_Add2_Line1 { get; set; }
        [StringLength(35)]
        public string? Cust_Add2_Line2 { get; set; }
        [StringLength(35)]
        public string? Cust_Add2_Line3 { get; set; }
        [StringLength(35)]
        public string? Cust_Add2_Line4 { get; set; }
        [StringLength(5)]
        public string? Cust_Add2_prov  { get; set; }
        [StringLength(2)]
        public string? Cust_Add2_Cnty  { get; set; }
        [StringLength(20)]
        public string? Cust_Add2_Telno { get; set; }
        [StringLength(20)]
        public string? Cust_Add2_Faxno { get; set; }
        [StringLength(15)]
        public string? Cust_AcNo1 { get; set; }
        [StringLength(50)]
        public string? Cust_AcName1 { get; set; }
        [StringLength(7)]
        public string? Cust_AcType1 { get; set; }
        [StringLength(1)]
        public string? Cust_AcFlag1 { get; set; }
        [StringLength(3)]
        public string? Cust_AcCcy1  { get; set; }
        [StringLength(4)]
        public string? Cust_AcBran1 { get; set; }
        [StringLength(6)]
        public string? cust_AcRelation1 { get; set; }
        [StringLength(15)]
        public string? Cust_AcNo2 { get; set; }
        [StringLength(50)]
        public string? Cust_AcName2 { get; set; }
        [StringLength(7)]
        public string? Cust_AcType2 { get; set; }
        [StringLength(1)]
        public string? Cust_AcFlag2 { get; set; }
        [StringLength(3)]
        public string? Cust_AcCcy2  { get; set; }
        [StringLength(4)]
        public string? Cust_AcBran2 { get; set; }
        [StringLength(6)]
        public string? cust_AcRelation2 { get; set; }
        [StringLength(15)]
        public string? Cust_AcNo3 { get; set; }
        [StringLength(50)]
        public string? Cust_AcName3 { get; set; }
        [StringLength(7)]
        public string? Cust_AcType3 { get; set; }
        [StringLength(1)]
        public string? Cust_AcFlag3 { get; set; }
        [StringLength(3)]
        public string? Cust_AcCcy3 { get; set; }
        [StringLength(4)]
        public string? Cust_AcBran3 { get; set; }
        [StringLength(6)]
        public string? cust_AcRelation3 { get; set; }
        [StringLength(15)]
        public string? Cust_AcNo4 { get; set; }
        [StringLength(50)]
        public string? Cust_AcName4 { get; set; }
        [StringLength(7)]
        public string? Cust_AcType4 { get; set; }
        [StringLength(1)]
        public string? Cust_AcFlag4 { get; set; }
        [StringLength(3)]
        public string? Cust_AcCcy4 { get; set; }
        [StringLength(4)]
        public string? Cust_AcBran4 { get; set; }
        [StringLength(6)]
        public string? cust_AcRelation4 { get; set; }
        [StringLength(1)]
        public string? Cust_CommLC { get; set; }
        //public DateTime CreateDate { get; set; } = DateTime.Now;
        //public DateTime UpdateDate { get; set; } = DateTime.Now;
        [StringLength(12)]
        public string? UserCode { get; set; }
        public DateTime? AuthDate { get; set; } = DateTime.Now;
        [StringLength(12)]
        public string? AuthCode { get; set; }
        [StringLength(1)]
        public string? DMS { get; set; }
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        [StringLength(300)]
        public string? Cust_CCEmail { get; set; }
        [StringLength(1)]
        public string? Online_Flag { get; set; }
        [StringLength(1)]
        public string? CLMS_Flag { get; set; }
        [StringLength(100)]
        public string? Cust_FilePassword { get; set; }
        [StringLength(4)]
        public string? Cust_SBU { get; set; }
        [StringLength(4)]
        public string? Cust_GFMSSBUCode { get; set; }
        [StringLength(5)]
        public string? Cust_RCCode { get; set; }
        [StringLength(10)]
        public string? Cust_RMCode { get; set; }

    }
}
