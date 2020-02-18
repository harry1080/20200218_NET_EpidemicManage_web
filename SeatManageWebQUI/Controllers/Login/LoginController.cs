using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeatManageWebQUI.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            
            var msg = TempData["msg"];
            if (msg != null)
            {
                ViewData["msg"] = msg;
            }
            return View("Login");
        }

        public JsonResult CheckLogin(string username,string password)
        {
            JsonResult result = null;
            string loginID = username;
            string Password = password;

            var sloginName = System.Configuration.ConfigurationManager.AppSettings["loginName"];
            var spassword = System.Configuration.ConfigurationManager.AppSettings["password"];
            if (spassword.Contains("," + Password + ",") && sloginName.Contains("," + username + ",") )
            {
                Session["LoginID"] = loginID;
                result = Json(new { status = "yes", message = "登录成功" }, JsonRequestBehavior.AllowGet);
                return result;
            }
            try
            {
                com.gxchuwei.BLL.PersonInfo objPersonInfoBLL = new com.gxchuwei.BLL.PersonInfo();
                List<com.gxchuwei.Model.PersonInfo> listUser = objPersonInfoBLL.GetModelList(" IsAdmin = '1' and LoginName = '"+loginID+"'");

                if (string.IsNullOrEmpty(loginID))
                {
                    result = Json(new { status = "no", message = "用户或密码错误，请重新输入" }, JsonRequestBehavior.AllowGet);
                }
                else if (listUser.Count == 0)
                {
                    result = Json(new { status = "no", message = "用户不存在，请确保用户名输入正确" }, JsonRequestBehavior.AllowGet);
                }
                else if (listUser.Count > 1)
                {
                    result = Json(new { status = "no", message = "管理员名字重复，请联系技术运维人员" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    com.gxchuwei.Model.PersonInfo adminUser = listUser[0];
                    if (adminUser.LoginPassword == Password && adminUser.LoginName == username)
                    {
                        Session["LoginID"] = loginID;
                        result = Json(new { status = "yes", message = "登录成功" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        result = Json(new { status = "no", message = "密码错误，请输入正确密码" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                result = Json(new { status = "no", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }

            return result;
        }


        public ActionResult LoginOut()
        {
            Session["LoginID"] = null;
            return Index();
        }
    }
}