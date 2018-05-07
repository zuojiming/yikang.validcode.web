using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yikang.validcode.core;
using yikang.validcode.data;
using yikang.validcode.data.Model.co;
using System.Web;

namespace yikang.validcode.admin.Controllers.apis
{
    using Newtonsoft.Json;
    using System.Security;
    using System.Web.Security;
    using yikang.validcode.admin.Models;

    [RoutePrefix("api/users")]
    public class UsersController : BaseController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(User pu)
        {
            string loginName = pu.LoginName, passWord = pu.Pwd;
            User returnUser = new User();
            using (ValidCodeContext context = new ValidCodeContext())
            {
                var user = context.Users.FirstOrDefault(u => u.LoginName == loginName && (u.UserType == UserTypeEnum.管理员 || u.UserType == UserTypeEnum.后台账户));
                if (user == null)
                {
                    return Json(null, false, "无此登录名", HttpStatusCode.NotAcceptable);
                }
                if (user.Pwd != Md5Helper.Md5Encode(passWord))
                {
                    return Json(null, false, "用户名或密码错误", HttpStatusCode.NotAcceptable);
                }
                FormsTicket(user);
                returnUser = user;
            }
            return Json(returnUser);
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(User insertUser)
        {
            int result = 0;
            using (ValidCodeContext context = new ValidCodeContext())
            {
                context.Users.Add(insertUser);
                result = context.SaveChanges();
            }
            return Json(result, true, "新增成功");
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(User user)
        {
            int result = 0;
            using (ValidCodeContext context = new ValidCodeContext())
            {
                var fu = context.Users.First(f => f.Id == user.Id);
                fu.Mobile = user.Mobile;
                fu.NIckName = user.NIckName;
                fu.QQ = user.QQ;
                if (!string.IsNullOrWhiteSpace(user.Pwd))
                    fu.Pwd = Md5Helper.Md5Encode(user.Pwd);
                fu.CompanyName = user.CompanyName;
                fu.Status = user.Status;
                result = context.SaveChanges();
            }
            return Json(result, true, "修改成功");
        }

        [HttpPost]
        [Route("del")]
        public HttpResponseMessage Delete(int id = 0, int[] ids = null)
        {
            ids = ids ?? new int[0];
            if (id > 0)
            {
                var idlist = ids.ToList();
                idlist.Add(id);
                ids = idlist.ToArray();
            }
            int result = 0;
            if (ids.Length > 0)
                using (ValidCodeContext context = new ValidCodeContext())
                {
                    var fu = context.Users.Where(w => ids.Contains(w.Id));
                    foreach (var item in fu)
                    {
                        item.IsEnabled = 0;
                    }
                    result = context.SaveChanges();
                }
            return Json(result, true, "删除成功");
        }

        [HttpPost]
        [Route("initpwd")]
        public HttpResponseMessage InitPwd(int id = 0, List<int> ids = null)
        {
            ids = ids ?? new List<int>();
            if (id > 0)
            {
                var idlist = ids.ToList();
                idlist.Add(id);
                ids = idlist.ToList();
            }
            int result = 0;
            if (ids.Count > 0)
                using (ValidCodeContext context = new ValidCodeContext())
                {
                    var fu = context.Users.Where(w => ids.Contains(w.Id));
                    foreach (var item in fu)
                    {
                        item.Pwd = DateTime.Now.ToString("123456654321");
                    }
                    result = context.SaveChanges();
                }
            return Json(result, true, "修改成功");
        }

        [HttpPost]
        [Route("list")]
        public HttpResponseMessage List(NormalSearchVO searchVO)
        {
            int pageidx = searchVO.pageidx;
            int pagesize = searchVO.pagesize;
            List<User> userList = new List<User>();
            int count = 0;
            using (ValidCodeContext context = new ValidCodeContext())
            {
                count = context.Users.Where(w => w.IsEnabled == 1).Count();
                var searchIcon = context.Users.Where(w => w.IsEnabled == 1);
                if (!string.IsNullOrWhiteSpace(searchVO.searchval)) {
                    if (searchVO.searchkey == "loginname")
                    {
                        searchIcon = searchIcon.Where(w => w.LoginName.IndexOf(searchVO.searchval) >= 0);
                    }
                }
                userList = searchIcon.OrderByDescending(o => o.Id).Skip(pageidx - 1).Take(pagesize).ToList();

            }
            return Json(new
            {
                t = count,
                l = userList
            });
        }

        private void FormsTicket(User user)
        {
            FormsAuthentication.SetAuthCookie(user.LoginName, true, "/");
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.LoginName, DateTime.Now, DateTime.Now.AddDays(7), true, JsonConvert.SerializeObject(user));
            string strTicker = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, strTicker);
            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("__username", user.NIckName));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("__loginname", user.LoginName));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("__blanace", user.Balance.ToString()));
        }
    }
}
