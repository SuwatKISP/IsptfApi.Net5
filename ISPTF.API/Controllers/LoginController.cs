using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models;
using ISPTF.Commons;
using System.Data;
using System.Text;
using Dapper;
using ISPTF.DataAccess.DbAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ISPTF.API.Controllers
{
    
    //[EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ISPTFContext _context;
        private readonly IJwtAuth jwtAuth;
        private readonly ISqlDataAccess _db;
        public LoginController(ISqlDataAccess db, IJwtAuth jwtAuth, ISPTFContext context)
        {
            _context = context;
            _db = db;
            this.jwtAuth = jwtAuth;
        }

        [HttpPost]
        public async Task<ActionResult<LoginReturn>> Index([FromBody] UserLoginRequest userLogin)
        {
            string EnPassword = PasswordCheck.Encryption(userLogin.password);
            try
            {
                var item = (from row in _context.mUsers
                           where row.UserId == userLogin.username 
                                && row.UserPassword == EnPassword
                           select row).FirstOrDefault();
                if (item != null)
                {
                    var response = new LoginReturn();
                    response = new LoginReturn
                    {
                        userId = item.UserId,
                        userBran = item.UserBran,
                        userEmail = item.UserEmail,
                        userName = item.UserName,
                        userLevel = item.UserLevel,
                        userRole = item.UserDept,
                        userToken = jwtAuth.Authentication(userLogin.username, userLogin.password),
                        //PasswordEncrypted= PasswordCheck.Encryption(userLogin.password)
                    };
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
        //[HttpPost("decrypt")]
        //public ActionResult Decrypt(string encryptPassword)
        //{
        //    var result=PasswordCheck.Decryption(encryptPassword);
        //    return Ok(result);
        //    //int pwdLength = Convert.ToInt16(encryptPassword.Substring(0, 1));
        //    //int pwdPtr = 1;
        //    //int pwdSubLength = 0;
        //    //string pwdStr = "";
        //    //string pwdTemp = "";
        //    ////string FOper1 = "*+*+*+*+*+*+";
        //    //string FOper1 = "/-/-/-/-/-/-";
        //    ////string FOper2 = "+*-*+*-*+*+*";
        //    //string FOper2 = "-/+/-/+/-/-/";
        //    //int[] FValue1 = { 8, 2, 6, 3, 2, 5, 4, 2, 9, 10, 7, 12 };
        //    //int[] FValue2 = { 9, 4, 3, 2, 7, 2, 10, 6, 4, 5, 11, 6 };
        //    //for (int i = 0; i < pwdLength; i++)
        //    //{
        //    //    pwdSubLength = Convert.ToInt32(encryptPassword.Substring(pwdPtr, 1));
        //    //    pwdPtr++;
        //    //    pwdTemp = "(" + encryptPassword.Substring(pwdPtr, pwdSubLength) + FOper2[i] + FValue2[i] + ")" + FOper1[i] + FValue1[i];
        //    //    var dt = new DataTable();
        //    //    dt.Columns.Add("r", typeof(int), pwdTemp);
        //    //    dt.Rows.Add();
        //    //    pwdStr += Convert.ToChar(dt.Rows[0][0]);
        //    //    pwdPtr += pwdSubLength;
        //    //}
        //    //return Ok(pwdStr);
        //}
        //[HttpPost("encrypt")]
        //public ActionResult Encrypt(string password)
        //{
        //    var result= PasswordCheck.Encryption(password);
        //    return Ok(result);

        //    //int[] pwdLength = new int[12];
        //    //string[] pwdStr = new string[12];
        //    //string EnPassword = "";
        //    //string FOper1 = "*+*+*+*+*+*+";
        //    //string FOper2 = "+*-*+*-*+*+*";
        //    //int[] FValue1 = { 8, 2, 6, 3, 2, 5, 4, 2, 9, 10, 7, 12 };
        //    //int[] FValue2 = { 9, 4, 3, 2, 7, 2, 10, 6, 4, 5, 11, 6 };
        //    //int passwordLength = password.Length;

        //    //byte[] pwdAscii = Encoding.ASCII.GetBytes(password);

        //    //for (int i = 0; i < passwordLength; i++)
        //    //{
        //    //    pwdStr[i] = "(" + Convert.ToString(pwdAscii[i]) + FOper1[i] + FValue1[i] + ")" + FOper2[i] + FValue2[i];

        //    //    var dt = new DataTable();
        //    //    dt.Columns.Add("r", typeof(int), pwdStr[i]);
        //    //    dt.Rows.Add();
        //    //    pwdLength[i] = Convert.ToString((int)dt.Rows[0][0]).Length;
        //    //    EnPassword += Convert.ToString(pwdLength[i]) + Convert.ToString((int)dt.Rows[0][0]);


        //    //}
        //    //return Ok(Convert.ToString(passwordLength)+EnPassword);
        //}

    }
}
