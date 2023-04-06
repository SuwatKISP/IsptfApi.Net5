using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Commons
{
    public class PasswordCheck
    {
        public static string Decryption(string encryptPassword)
        {
            int pwdLength = Convert.ToInt16(encryptPassword.Substring(0, 1));
            int pwdPtr = 1;
            int pwdSubLength = 0;
            string pwdStr = "";
            string pwdTemp = "";
            //string FOper1 = "*+*+*+*+*+*+";
            string FOper1 = "/-/-/-/-/-/-";
            //string FOper2 = "+*-*+*-*+*+*";
            string FOper2 = "-/+/-/+/-/-/";
            int[] FValue1 = { 8, 2, 6, 3, 2, 5, 4, 2, 9, 10, 7, 12 };
            int[] FValue2 = { 9, 4, 3, 2, 7, 2, 10, 6, 4, 5, 11, 6 };
            for (int i = 0; i < pwdLength; i++)
            {
                pwdSubLength = Convert.ToInt32(encryptPassword.Substring(pwdPtr, 1));
                pwdPtr++;
                pwdTemp = "(" + encryptPassword.Substring(pwdPtr, pwdSubLength) + FOper2[i] + FValue2[i] + ")" + FOper1[i] + FValue1[i];
                var dt = new DataTable();
                dt.Columns.Add("r", typeof(int), pwdTemp);
                dt.Rows.Add();
                pwdStr += Convert.ToChar(dt.Rows[0][0]);
                pwdPtr += pwdSubLength;
            }
            return pwdStr;
        }
        public static string Encryption(string password)
        {
            int[] pwdLength = new int[12];
            string[] pwdStr = new string[12];
            string EnPassword = "";
            string FOper1 = "*+*+*+*+*+*+";
            string FOper2 = "+*-*+*-*+*+*";
            int[] FValue1 = { 8, 2, 6, 3, 2, 5, 4, 2, 9, 10, 7, 12 };
            int[] FValue2 = { 9, 4, 3, 2, 7, 2, 10, 6, 4, 5, 11, 6 };
            int passwordLength = password.Length;

            byte[] pwdAscii = Encoding.ASCII.GetBytes(password);

            for (int i = 0; i < passwordLength; i++)
            {
                pwdStr[i] = "(" + Convert.ToString(pwdAscii[i]) + FOper1[i] + FValue1[i] + ")" + FOper2[i] + FValue2[i];

                var dt = new DataTable();
                dt.Columns.Add("r", typeof(int), pwdStr[i]);
                dt.Rows.Add();
                pwdLength[i] = Convert.ToString((int)dt.Rows[0][0]).Length;
                EnPassword += Convert.ToString(pwdLength[i]) + Convert.ToString((int)dt.Rows[0][0]);
            }
            return Convert.ToString(passwordLength) + EnPassword;
        }
    }
    
}
