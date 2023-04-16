namespace ISPTF.Models.ExportLC
{
    public class PEXLCRecordResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXLCRecordRsp Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
