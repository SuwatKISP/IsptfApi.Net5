using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class SqlQuery
    {
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string Condition { get; set; }
        public string OrderName { get; set; }
        public int RowCount { get; set; }
        //public int Page { get; set; } = 1;
        //public int PageSize { get; set; } = 10;
    }
}
