﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportLC.AcceptTermDueWREF
{
    public class EXLCAcceptTermDueWREFListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCAcceptTermDueListPageRsp> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
