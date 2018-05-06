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
                return UserMd5(key);
            }
        }
        public string UserMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("x2");

            }
            return pwd;
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
