using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using yikang.validcode.data.Model.co;

namespace yikang.validcode.admin.Controllers.apis
{
    public class BaseController : ApiController
    {
        [NonAction]
        public HttpResponseMessage Json(object data,bool success = true,string message = "",HttpStatusCode code = HttpStatusCode.OK) {
            HttpResponseMessage msg = new HttpResponseMessage(code);
            var body = new {
                d = data,
                s = success,
                m = message
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(body),Encoding.UTF8,"application/json");
            msg.Content = content;
            return msg;
        }
        [NonAction]
        public HttpResponseMessage OK(object data, bool success = true, string message = "")
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.OK);
            var body = new
            {
                d = data,
                s = success,
                m = message
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            msg.Content = content;
            return msg;
        }
        [NonAction]
        public HttpResponseMessage Faild(string message, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            HttpResponseMessage msg = new HttpResponseMessage(code);
            msg.ReasonPhrase = message;
            return msg;
        }

        public User LoginUser {
            get {
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                var userdata = FormsAuthentication.Decrypt(cookie.Value)?.UserData;
                var user = JsonConvert.DeserializeObject<User>(FormsAuthentication.Decrypt(cookie.Value)?.UserData);
                return user;
            }
        }
    }
}
