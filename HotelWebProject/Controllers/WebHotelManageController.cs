using BLL;
using HotelWebProject.AppHelper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebProject.Controllers
{
    public class WebHotelManageController : Controller
    {
        // GET: SysAdmin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(SysAdmins model)
        {
            var loginpwd = MD5Helper.MD5Encrypt32(model.LoginPwd);
            var loginname = model.LoginName;
            var loginuser = SysAdminBLL.Get(m => m.LoginName == loginname && m.LoginPwd == loginpwd);
            if (loginuser != null)//当用户名和密码正确时
            {
                //页面跳转到主页面
                return RedirectToAction("Index");
            }
            else
            {
                //如果登录不成功，则向用户提示错误信息
                ViewBag.ErrorMsg = "用户名或密码错误。";
                return View(model);
            }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}