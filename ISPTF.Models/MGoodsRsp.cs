using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MGoodsRsp : MGoods
    {
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
    }
}
