using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace ISPTF.Commons
{
    public static class ModDate
    {
        // static get configuration from appsettings.json
        private static IConfiguration config;
        public static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                config = builder.Build();
                return config;
            }
        }
        //private readonly IConfiguration Configuration;

        //public ModDate(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    StaticConfig = configuration;
        //}
        //public static IConfiguration StaticConfig { get; private set; }

        public static string last_date(string mytext)
        {
            string last_date="__/__/____";
            double eyear=int.Parse(mytext.Substring(mytext.Length-4,4));
            string mday=mytext.Substring(3,2);
            string dday=mytext.Substring(0,2);

            switch (mday)
            {
                case "01":
                case "03":
                case "05":
                case "07":
                case "08":
                case "10":
                case "12":
                    {
                        last_date = "31/" + mday + "/" + eyear.ToString();
                        break;
                    }
                case "02":
                    {
                        if ((eyear-543)%4==0)
                        {
                            last_date = "29/" + mday + "/" + eyear.ToString();
                        }
                        else
                        {
                            last_date = "28/" + mday + "/" + eyear.ToString();
                        }
                        break;
                    }
                case "04":
                case "06":
                case "09":
                case "11":
                    {
                        last_date = "30/" + mday + "/" + eyear.ToString();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }


            return last_date;
        }
        public static string fullDatePS(string dt)
        {
            // dt yyyy/MM/dd;
            string dD;
            string mm=string.Empty;
            dD = dt.Substring(dt.Length - 2, 2);
            switch (dt.Substring(5, 2))
            {
                case "01":
                    {
                        mm = "เดือน มกราคม พ.ศ. ";
                        break;
                    }
                case "02":
                    {
                        mm = "เดือน กุมภาพันธ์ พ.ศ. ";
                        break;
                    }
                case "03":
                    {
                        mm = "เดือน มีนาคม พ.ศ. ";
                        break;
                    }
                case "04":
                    {
                        mm = "เดือน เมษายน พ.ศ. ";
                        break;
                    }
                case "05":
                    {
                        mm = "เดือน พฤษภาคม พ.ศ. ";
                        break;
                    }
                case "06":
                    {
                        mm = "เดือน มิถุนายน พ.ศ. ";
                        break;
                    }
                case "07":
                    {
                        mm = "เดือน กรกฎาคม พ.ศ. ";
                        break;
                    }
                case "08":
                    {
                        mm = "เดือน สิงหาคม พ.ศ. ";
                        break;
                    }
                case "09":
                    {
                        mm = "เดือน กันยายน พ.ศ. ";
                        break;
                    }
                case "10":
                    {
                        mm = "เดือน ตุลาคม พ.ศ. ";
                        break;
                    }
                case "11":
                    {
                        mm = "เดือน พฤศจิกายน พ.ศ. ";
                        break;
                    }
                case "12":
                    {
                        mm = "เดือน ธันวาคม พ.ศ. ";
                        break;
                    }
            }
            return "วันที่ " + dD + " " + mm + (int.Parse(dt.Substring(0, 4)) + 543).ToString();
        }
        public static object getDate(string tDate,string sign)
        {
            // แสดงค่า วันที่่ตามชนิดของ sign
            // sign ='S', tdate(dd/mm/yyyy)  ค่าวันที่ที่ได้ format = yyyymmdd
            // sign ='D', tdate(yyyymmdd)  ค่าวันที่ที่ได้ format = dd/mm/yyyy

            string tmp = string.Empty;
            double tmpdate;


            if (sign=="D")
            {
                if(tDate.Length<8)
                {
                    tmp = "__/__/____";
                }
                else
                {
                    tmp = tDate.Substring(6,2)+"/"+tDate.Substring(4,2)+"/"+tDate.Substring(0,4);
                }
            }
            else if (sign=="S")
            {
                if (int.Parse(tDate.Substring(tDate.Length-4,4))<2400)
                {
                    tmpdate = int.Parse(tDate.Substring(tDate.Length - 4, 4)) + 543;
                }
                else
                {
                    tmpdate = int.Parse(tDate.Substring(tDate.Length - 4, 4));
                }
                tmp = tmpdate.ToString();
            }
            return tmp;
        }
        public static short DateDF(int sDate,int eDate,string cType)
        {
            // sDate "yyyyMMddd"
            // eDate "yyyyMMddd"
            // cType d-date,n-minute,y-year
            string pdate;
            string pdate1;

            string fDate = string.Empty;
            string nDate = string.Empty;

            return 0;
        }
        public static short DateAd(ref short myDate,double cNum,string cType)
        {
            string fDate = string.Empty;
            string nDate = string.Empty;

            return 0;
        }
        public static string GetSysDate()
        {
            return GetSystemDateTime().ToString("dd/MM/yyyy");
        }
        public static string GetSystime()   // DateTime From Client DateTime
        {
            return GetSystemDateTime().ToString("hh.mm");
        }
        public static string GetDateNow1()
        {
            // "yyyy/MM/dd hh:mm"
            return DateTime.Today.ToString("yyyy/MM/dd hh.mm.ss");
        }
        public static string GetDateNow()   // DateTime from Server DataTime
        {
            DateTime GetSysDateTime = GetSystemDateTime();
            string GetDateNow=string.Empty;
            
            // 5 char of sql current_timestamp format 114 (hh:mi:ss:mmm)
            string GetSysTime = GetSysDateTime.ToString("hh:mm:ss");

            // "yyyy/MM/dd hh:mm"
            return GetDateNow = GetSysDateTime.ToString("yyyy/MM/dd ") + GetSysTime;
        }

        public static DateTime GetSystemDateTime()
        {
            //  private readonly IConfiguration Configuration;

            //public GetSystemDateTime(IConfiguration configuration)
            //{
            //    Configuration = configuration;
            //}
            //var url = Configuration["AllowedOrigins"];
            // var url = new Uri("https://tfispau.cimbthai.com:8085/isptfapi//api/SystemDateTime");

            var url = new Uri(Configuration["BaseUrlApi"] + "/api/systemdatetime");
            HttpClient client = new();
            try
            {
                var response = client.GetAsync(url).Result;
                string jString = response.Content.ReadAsStringAsync().Result;
                GetSystemDateTime results = JsonConvert.DeserializeObject<GetSystemDateTime>(jString);
                return results.sysDateTime;
            }
            catch (Exception e)
            {
                return DateTime.Now;
            }

        }
        public static DateTime GetSystemDateTimebk()
        {
            //  private readonly IConfiguration Configuration;

            //public GetSystemDateTime(IConfiguration configuration)
            //{
            //    Configuration = configuration;
            //}
            //var url = Configuration["AllowedOrigins"];
            // var url = new Uri("https://tfispau.cimbthai.com:8085/isptfapi//api/SystemDateTime");

            //var url = new Uri(Configuration["BaseUrlApi"] + "/api/systemdatetime");
            //HttpClient client = new();
            //try
            //{
            //    var response = client.GetAsync(url).Result;
            //    string jString = response.Content.ReadAsStringAsync().Result;
            //    GetSystemDateTime results = JsonConvert.DeserializeObject<GetSystemDateTime>(jString);
            //    return results.sysDateTime;
            //}
            //catch (Exception e)
            //{
            //    return DateTime.Now;
            //}


            var url = "https://203.154.158.182/isptf.api/api/systemdatetime";
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            clientHandler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            var client = new HttpClient(clientHandler);
            var response =  client.GetAsync(url).Result;
           string jString = response.Content.ReadAsStringAsync().Result;
            var results = JsonConvert.DeserializeObject<GetSystemDateTime>(jString);
            DateTime xx = Convert.ToDateTime( results.sysDateTime) ;
            return xx;

        }

        public static GetSystemDateTime GetSystemDateTimeNew()
        {
            //var url = "http://localhost:10055/api/EKYC";
            var url = "https://203.154.158.182/isptf.api/api/systemdatetime";
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            clientHandler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            var client = new HttpClient(clientHandler);
            //client.Timeout = TimeSpan.FromMinutes(3);
            //HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url);
            //msg.Headers.Add("User-Agent", "C# Program Get");
            //var res= await client.SendAsync(msg);

                var res = client.GetAsync(url).Result;
                string resString = res.Content.ReadAsStringAsync().Result;

                GetSystemDateTime[] response = JsonConvert.DeserializeObject<GetSystemDateTime[]>(resString);

                return response[0];

                //return Ok(< GetSystemDateTime > response);

                //return new ContentResult
                //{
                //    StatusCode=(int)res.StatusCode,
                //    //StatusCode=200,
                //    Content = response,
                //    ContentType = "application/json,Encoding.UTF8"
                //};

           }
        public static DateTime GetSystemDateCond( string dateFlag)
        {
            //  private readonly IConfiguration Configuration;

            //public GetSystemDateTime(IConfiguration configuration)
            //{
            //    Configuration = configuration;
            //}
            //var url = Configuration["AllowedOrigins"];
            // var url = new Uri("https://tfispau.cimbthai.com:8085/isptfapi//api/SystemDateTime");
  
            
            var url = new Uri(Configuration["BaseUrlApi"] + "/api/systemdatetime2");
            //var url = new Uri("http://203.154.158.182/isptf.api//api/SystemDateTime");
            HttpClient client = new();
            try
            {
                var response = client.GetAsync(url).Result;
                string jString = response.Content.ReadAsStringAsync().Result;
                GetSystemDateTime results = JsonConvert.DeserializeObject<GetSystemDateTime>(jString);
                return DateTime.Now;// results.sysDateTime;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }

        }
    }
}
