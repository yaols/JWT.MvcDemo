using JWT.MvcDemo.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JWT.MvcDemo.App_Start
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 验证入口
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// 验证核心代码
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {


            //前端请求api时会将token存放在名为"auth"的请求头中
            var authHeader = httpContext.Request.Headers["auth"];
            if (authHeader == null)
                return false;



            var userinfo = JwtHelp.GetJwtDecode(authHeader);
            //举个例子  生成jwtToken 存入redis中    
            //这个地方用jwtToken当作key 获取实体val   然后看看jwtToken根据redis是否一样
            if (userinfo.UserName == "admin" && userinfo.Pwd == "123")
                return true;


            return false;
        }

        /// <summary>
        /// 验证失败处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            base.HandleUnauthorizedRequest(filterContext);

            filterContext.Result = new RedirectResult("/Error");
            filterContext.HttpContext.Response.Redirect("/Home/Error");

        }
    }
}