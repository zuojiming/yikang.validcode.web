using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace yikang.validcode.admin.Controllers.apis
{
    public class BaseController : ApiController
    {
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
    }
}
