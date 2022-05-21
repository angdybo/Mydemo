using logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wouse.Controllers
{
    public class HomeController : BaseController
    {
        logicUser logicUser = new logicUser();
        logicGoods logicGoods = new logicGoods();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult GoodsList()
        {
            return View();
        }
 
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return ErrorResult("缺少必要参数，请求失败");
            }
            else
            {
                var data = logicUser.CheckLogin(username, password);
                if (data != null)
                {
                    return SuccessResult("登录成功");
                }
                else
                {
                    return ErrorResult("登录失败");
                }
            }
        }
       
        public string GetGoodsList(string keyWord)
        {
            var data = logicGoods.GetGoodsList(keyWord);
            return data.ToJsonCon();
        }
    }
}