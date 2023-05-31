using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int? SeqNo { get; set; }
        public string UserPassword { get; set; }
        public string UserPassword1 { get; set; }
        public string UserPassword2 { get; set; }
        public string UserPassword3 { get; set; }
        public DateTime? UserPasswordChangeDate { get; set; }
        public DateTime? UserPasswordExpiryDate { get; set; }
        public DateTime? UserStartDate { get; set; }
        public DateTime? UserExpiryDate { get; set; }
        public DateTime? UserLockDate { get; set; }
        public string UserLevel { get; set; }
        public string UserDept { get; set; }
        public string UserRemark { get; set; }
        public int? LockNo { get; set; }
        public string UserStatus { get; set; }
        public string UserFlag { get; set; }
        public string UserBran { get; set; }
        public string UserEmail { get; set; }
    }
}
