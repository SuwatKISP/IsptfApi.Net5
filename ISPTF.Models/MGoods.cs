using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MGoods
    {
        [Required(ErrorMessage = "Goods  Code is required")]
        //[Range(10, 10, ErrorMessage = "Limit Code must be 10 character")]
        [StringLength(4)]
        public string goods_Code { get; set; }
        public string goods_Desc { get; set; }
        public string goods_Purpose { get; set; }
        public string userCode { get; set; }
    }
}
