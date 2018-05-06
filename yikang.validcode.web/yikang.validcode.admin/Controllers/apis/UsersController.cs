using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yikang.validcode.data;

namespace yikang.validcode.admin.Controllers.apis
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(string userName,string passWord) {
            ValidCodeContext context = new ValidCodeContext();
            //context.Users.Where();
            return null;
        }
    }
}
