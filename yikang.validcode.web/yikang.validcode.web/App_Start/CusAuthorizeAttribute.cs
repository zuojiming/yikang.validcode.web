using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace yikang.validcode.web
{
    public class CusAuthorizeAttribute : FilterAttribute, IAuthenticationFilter

    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //这个方法是在Action执行之前调用
            var user = filterContext.HttpContext.Session["userinfo"];
            if (user != null) return;
            var url = new UrlHelper(filterContext.RequestContext).Action("Login", "Auth", new {id = ""});
            filterContext.Result = new RedirectResult(url);
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}