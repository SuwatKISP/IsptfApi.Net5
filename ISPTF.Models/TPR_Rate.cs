using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class TPR_Rate
    {
        [StringLength(20, MinimumLength = 3)]
        public string Rate_Type { get; set; } = "TPR";

        [StringLength(3, MinimumLength = 3)]
        public string CurCode { get; set; }

        [StringLength(10, MinimumLength = 3)]
        public string TermType { get; set; }

        public float Rate { get; set; }
        public string RateDate { get; set; }

        [StringLength(1, MinimumLength = 1)]
        public string Delete_Flag { get; set; } = "0";

        [StringLength(1, MinimumLength = 1)]
        public string Load_Flag { get; set; } = "N";

        public string ZZStrdate { get; set; }
        public string ZZDate { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public string ZZUser { get; set; }

        [StringLength(200, MinimumLength = 0)]
        public string FileName { get; set; }
    }
}
