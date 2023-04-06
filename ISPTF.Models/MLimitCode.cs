using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MLimitCode
    {
        [Required(ErrorMessage = "Limit  Code is required")]
        //[Range(10, 10, ErrorMessage = "Limit Code must be 10 character")]
        [StringLength(10)]
        public string limit_Code { get; set; } = "ART";
        [StringLength(35)]
        public string limit_Name { get; set; }
        [StringLength(1)]
        public string limit_UseFor { get; set; }
        [StringLength(1)]
        public string limit_UseCcy { get; set; }
        [StringLength(1)]
        public string limit_IMEX { get; set; }
        [StringLength(1)]
        public string limit_IMLC { get; set; }
        [StringLength(1)]
        public string limit_IMTR { get; set; }
        [StringLength(1)]
        public string limit_EXLC { get; set; }
        [StringLength(1)]
        public string limit_EXBC { get; set; }
        [StringLength(1)]
        public string limit_EXPC { get; set; }
        [StringLength(1)]
        public string limit_DLC { get; set; }
        [StringLength(1)]
        public string limit_IMP { get; set; }
        [StringLength(1)]
        public string limit_EXP { get; set; }
        [StringLength(1)]
        public string limit_LG { get; set; }
        [StringLength(12)]
        public string userCode { get; set; }
    }
}
