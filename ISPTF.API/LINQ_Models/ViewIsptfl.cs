using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewIsptfl
    {
        public string Module { get; set; }
        public string CustCode { get; set; }
        public string CustIsp { get; set; }
        public string CustTfl { get; set; }
        public string CustName { get; set; }
        public string Keynumber { get; set; }
        public string RefTfl { get; set; }
        public string CcyIsp { get; set; }
        public string CcyTfl { get; set; }
        public string CcsIsp { get; set; }
        public string CcsTfl { get; set; }
        public string CcsRelatedTfl { get; set; }
        public double? LmAmtIsp { get; set; }
        public decimal LmAmtTfl { get; set; }
        public double BalIsp { get; set; }
        public decimal? BalTfl { get; set; }
    }
}
