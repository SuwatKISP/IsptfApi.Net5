using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PEXDoc;
using ISPTF.Models.PSWExport;
namespace ISPTF.Models
{
    public class SendMailRequest
    {
        public string MailTo { get; set; }
        public string MailCC { get; set; }
        public string MailBCC { get; set; }
        public string MailFile1 { get; set; }
        public string MailFile2 { get; set; }
        public string MailFile3 { get; set; }
        public string MailMod { get; set; }
        public string UserSend { get; set; }
        public string cDocNo { get; set; }
    }
}
