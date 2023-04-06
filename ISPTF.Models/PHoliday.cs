using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class PHoliday
    {
        [Required(ErrorMessage="Hol_Year required")]
        [StringLength(4)]
        [RegularExpression(@"^[0-9]+$")]
        public string hol_Year { get; set; }
        [Required(ErrorMessage = "Hol_Date required")]
        [DataType(DataType.DateTime)]
        public DateTime hol_Date { get; set; }
        [StringLength(50)]
        public string hol_Desc { get; set; }
        [StringLength(1)]
        public string hol_RecStat { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime updateDate { get; set; }
        [StringLength(12)]
        public string userCode { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime authDate { get; set; }
        [StringLength(12)]
        public string authCode { get; set; }
    }
}
