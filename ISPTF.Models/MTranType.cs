using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MTranType
    {
        [Required(ErrorMessage = "TranType  Code is required")]
        //[Range(10, 10, ErrorMessage = "Limit Code must be 10 character")]
        [StringLength(3)]
        public string tran_Code { get; set; }
        public string tran_Desc { get; set; }
        public string userCode { get; set; }
    }
}
