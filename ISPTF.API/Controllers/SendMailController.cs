using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ISPTF.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using static ISPTF.API.Startup;

namespace ISPTF.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SendMailController : Controller
    {
        [HttpPost]
        public async Task<ActionResult<SendMailResultResponse>>SendMail([FromBody] SendMailRequest data)
        {
            SendMailResultResponse response = new SendMailResultResponse();

            try
            {
                // 1 - Update Master
                //var USER_ID = User.Identity.Name;
                //var claimsPrincipal = HttpContext.User;
                //var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
                var AppPath = ConfigurationHelper.config.GetSection("AppPath");
                //string[] cParams = new string[] { "dev", "Line1", "1" };

                ProcessStartInfo startInfo = new ProcessStartInfo(string.Concat(AppPath.Value, "TradeSendMail.exe"));
                startInfo.Arguments = data.MailTo + "|" + data.MailCC + "|" + data.MailBCC
                    + "|" + data.MailFile1
                    + "|" + data.MailFile2
                    + "|" + data.MailFile3
                    + "|" + data.MailMod
                    + "|" + data.UserSend
                    + "|" + data.cDocNo;
                    //+ "\"";
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                System.Diagnostics.Process.Start(startInfo);

                response.Code = "200";
                response.Message ="";
                return Ok(response);

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }
        }

    }

}
