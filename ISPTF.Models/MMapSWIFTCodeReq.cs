using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MMapSWIFTCodeReq
    {
        //[Required(ErrorMessage = "MTType required")]
        [StringLength(3)]
        public string mtType { get; set; }
        //[Required(ErrorMessage = "MTType required")]
        [StringLength(5)]
        public string fdNumber { get; set; }
    }
}
