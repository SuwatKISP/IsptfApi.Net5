using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class FTPRateTermRsp // Send Cur Code
    { 
        public string? TermType { get; set; }
        public string? TermDesc { get; set; }
        public string? CCY_Flag { get; set; }
    }
}