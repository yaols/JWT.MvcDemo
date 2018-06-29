using JWT.MvcDemo.Help;
using JWT.MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWT.MvcDemo.Controllers
{
    public class JwtController : Controller
    {
        // GET: Jwt
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建jwtToken
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public ActionResult CreateToken(string username, string pwd)
        {

            DataResult result = new DataResult();

            //假设用户名为"admin"，密码为"123"  
            if (username == "admin" && pwd == "123")
            {

                var payload = new Dictionary<string, object>
                {
                    { "username",username },
                    { "pwd", pwd }
                };

                result.Token = JwtHelp.SetJwtEncode(payload);
                result.Success = true;
                result.Message = "成功";
            }
            else
            {
                result.Token = "";
                result.Success = false;
                result.Message = "生成token失败";
            }

            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}