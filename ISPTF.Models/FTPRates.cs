using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class FTPRates
    {
        public string Tenor { get; set; }
        public float Base { get; set; }
        public float LP { get; set; }
        public float SRR { get; set; }
        public float LCC { get; set; }
        public float COF { get; set; }
    }
}
