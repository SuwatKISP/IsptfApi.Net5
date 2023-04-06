using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class PHolidayCodeReq
    {
        [Required(ErrorMessage ="Hol_Year is required")]
        [StringLength(4)]
        public string hol_Year { get; set; }
        [Required(ErrorMessage = "Hol_Date is required")]
        //[DataType(DataType.DateTime)]
        public string hol_Date { get; set; }
    }
}
