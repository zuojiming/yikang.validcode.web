using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using yikang.validcode.core;

namespace yikang.validcode.webservice
{
    public class AccountBusinessHelper
    {
        private static AccountBusinessHelper sine_ { get; set; }
        public static AccountBusinessHelper Initialize()
        {
            if (sine_ == null)
            {
                sine_ = new AccountBusinessHelper();
            }
            return sine_;
        }
        private AccountBusinessHelper()
        {

        }
        private const string USER_NAME = "service001";
        private const string PWD = "000000";
        private const string VN_USER = "service001";
        private const string APPKEY = "205d09d24ab844f7aa0ac503c46250bf";
        private const string APP_SECRET = "491f18ae24b1430e878c36580920b256";
        private const string SERVICE_URL = "http://125.211.219.27:10801";
        private const string VER = "200";
        private string Pid { get; set; }
        private string Mobile { get; set; }
        private string timeStamp_ = string.Empty;
        private string TimeStamp
        {
            get
            {
                return timeStamp_ = Convert.ToInt32(DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 16)).TotalSeconds).ToString();
            }
        }
        private string Sign_flag
        {
            get
            {
                string key = VN_USER + APPKEY + Pid + Mobile + timeStamp_ + APP_SECRET;
                return Md5Helper.Md5Encode(key);
            }
        }
        
        public void SendMessage(string pid, string mobile, string smsMsg)
        {
            this.Mobile = mobile;
            if (string.IsNullOrEmpty(pid))
            {
                pid = "10003";
            }
            this.Pid = pid;
            string formStr = $"vnUser={VN_USER}&appKey={APPKEY}&ver={VER}&pid={Pid}&vnTelNo={Mobile}&smsMsg={smsMsg}&timestamp={TimeStamp}&sign={Sign_flag}";
            string urlParams = HttpUtility.UrlEncode(formStr);
            string serviceUrl = $"{SERVICE_URL}/asyn/send.ashx?{formStr}".ToLower();

            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(serviceUrl);
            webRequest.Method = HttpMethod.Get.Method;
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var resultStream = webResponse.GetResponseStream();
            StreamReader sr = new StreamReader(resultStream, Encoding.UTF8);
            string result = sr.ReadToEnd();
        }

        public string ReceiveMessage(string pid, string mobile)
        {
            this.Mobile = mobile;
            if (string.IsNullOrEmpty(pid))
            {
                pid = "10003";
            }
            this.Pid = pid;
            string formStr = $"vnUser={VN_USER}&sign={Sign_flag}&pid={Pid}&mobile={Mobile}&timestamp={TimeStamp}&ver={VER}";
            string urlParams = HttpUtility.UrlEncode(formStr);
            string url = $"{SERVICE_URL}/asyn/scan.ashx?{formStr}";
            HttpWebRequest receiveRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            var receiveReponse = (HttpWebResponse)receiveRequest.GetResponse();
            var resultStream = receiveReponse.GetResponseStream();
            StreamReader sr = new StreamReader(resultStream);
            var result = sr.ReadToEnd();
            return result;
        }
    }
}
