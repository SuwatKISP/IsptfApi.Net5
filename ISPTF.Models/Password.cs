using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class Password
    {
        public string PasswordData { get; set; }
        public string EncryptValue1 { get; set; }
        public string EncryptOperation1 { get; set; }
        public string EncryptValue2 { get; set; }
        public string EncryptOperation2 { get; set; }
    }
    public class LoginReturn
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userBran { get; set; }
        public string userDept { get; set; }
        public string userLevel { get; set; }
        public string userRole { get; set; }
        public string OnePUse { get; set; }        
        public string userToken { get; set; }
   
        //public string PasswordEncrypted { get; set; }
    }
}
