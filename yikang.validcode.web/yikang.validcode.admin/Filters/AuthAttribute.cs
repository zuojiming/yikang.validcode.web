using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;
using yikang.validcode.data.Model.co;

namespace yikang.validcode.admin.Filters
{
    public class AuthAttribute : ActionFilterAttribute,IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var userdata = FormsAuthentication.Decrypt(cookie.Value)?.UserData;
            if (userdata == null) {
                filterContext.Result = new RedirectResult("/login.html");
                return;
            }
            var user = JsonConvert.DeserializeObject<User>(FormsAuthentication.Decrypt(cookie.Value)?.UserData);
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}