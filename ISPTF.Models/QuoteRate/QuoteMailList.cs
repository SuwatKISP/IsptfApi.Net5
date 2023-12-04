using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class QuoteMailList
    {
        public string? UserCode { get; set; }
        public string? UserName { get; set; }
        public string? UserRole { get; set; }
        public string? UserStatus { get; set; }
        public string? UserMail { get; set; }
        public string? GroupMail { get; set; }
        public int rCount { get; set; }

    }
}
