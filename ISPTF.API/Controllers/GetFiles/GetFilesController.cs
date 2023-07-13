using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ISPTF.Models.GetFiles;
using System.Net.Mime;


namespace ISPTF.API.Controllers.GetFiles
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFilesController : ControllerBase
    {

        private readonly ILogger<GetFilesController> _logger;

        public GetFilesController(ILogger<GetFilesController> logger)
        {
            _logger = logger;
            _logger.LogInformation("GetFilesController called");
        }
        [HttpPost("getfile")]
        public HttpResponseMessage Post([FromBody] fileDownload filedownload)
        {
            _logger.LogInformation("Download GetFile called");
            var stream = new MemoryStream();
            // processing the stream.

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    //FileName = "CertificationCard.pdf"
                    FileName = "c:\\temp\\logs\\" + filedownload.fileName + "." + filedownload.fileType
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");

            return result;
        }
        [HttpGet("gfile")]
        public async Task<ActionResult> GetFile(string fileName)
        //public async Task<ActionResult> PostFile([FromBody] fileDownload filedownload)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(
                fileName,
                //"c:\\temp\\logs\\" + filedownload.fileName + "." + filedownload.fileType,
                out var contentType))
            {
                contentType = "application/octet-stream";
            }
            //var bytes = await System.IO.File.ReadAllBytesAsync("c:\\temp\\logs\\" + filedownload.fileName + "." + filedownload.fileType);
            //return File(bytes, contentType, Path.GetFileName("c:\\temp\\logs\\" + filedownload.fileName + "." + filedownload.fileType));
            var bytes = await System.IO.File.ReadAllBytesAsync(fileName);
            return File(bytes, contentType, Path.GetFileName(fileName));
        }

        [HttpGet("gfile2")]
        public async Task<ActionResult> GetFile2(string fileName)
        //public async Task<ActionResult> PostFile([FromBody] fileDownload filedownload)
        {
            ContentDisposition cd = new ContentDisposition
            {
                FileName = fileName,
                Inline = true
            };
            //var provider = new FileExtensionContentTypeProvider();
            //if (!provider.TryGetContentType(
            //    fileName,
            //    //"c:\\temp\\logs\\" + filedownload.fileName + "." + filedownload.fileType,
            //    out var contentType))
            //{
            //    contentType = "application/octet-stream";
            //}
            //Response.Headers.Add("Content-Type", "application/pdf");
            //Response.Headers.Add("Content-Type", "application/octet-stream");
            int ifiletype = fileName.IndexOf('.') + 1;
            string filetype = fileName.Substring(ifiletype, fileName.Length - ifiletype);
            string contenttype = "application/";
            if (filetype == "pdf") contenttype += "pdf";
            else if (filetype == "xls" || filetype == "xlsx") contenttype += "vnd.oasis.opendocument.spreadsheet";
            else if (filetype == "doc" || filetype == "docx") contenttype += "vnd.oasis.opendocument.text";
            //else if (filetype == "xls" || filetype == "xlsx") contenttype += "vnd.ms-excel";
            //else if (filetype == "doc" || filetype == "docx") contenttype += "msword";
            //string contenttype=fileName.Substring(fileName.Length-3,3).ToLower()=="pdf" ?
            //    "application/pdf"
            //    :"application/octet-stream";
            Response.Headers.Add("Content-Type", contenttype);
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            //Response.Headers[HeaderNames.ContentDisposition] = new MimeKit.ContentDisposition { FileName = fileName, Disposition = MimeKit.ContentDisposition.Inline }.ToString();
            return new FileContentResult(System.IO.File.ReadAllBytes(fileName), contenttype);

        }

    }
}
