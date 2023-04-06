using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MPurpose
    {
        [Required(ErrorMessage = "Purpose  Code is required")]
        //[Range(10, 10, ErrorMessage = "Limit Code must be 10 character")]
        [StringLength(6)]
        public string pur_Code { get; set; }
        public string pur_Desc { get; set; }
        [StringLength(12)]
        public string userCode { get; set; }
    }
}
