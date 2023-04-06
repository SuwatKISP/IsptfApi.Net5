using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class SystemDateTime
    {
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd hh:mm:dd}", ApplyFormatInEditMode = true)]
        public DateTime SysDateTime { get; set; }
    }
}
