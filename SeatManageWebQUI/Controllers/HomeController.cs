using System.Web.Mvc;
using DBUtility;
using SeatManage.SeatManageComm;
using System.Collections.Generic;
using System.Text;

namespace SeatManageWebQUI.Controllers
{
    public class HomeController : BaseController
    {
        private string LoadData()
        {
            //获取用户信息
            string loginID =  Session["LoginID"].ToString();
            com.gxchuwei.BLL.PersonInfo objPersonInfoBLL = new com.gxchuwei.BLL.PersonInfo();
            string msg = "您好,欢迎你回来！";
            ViewBag.welcomeMsg = msg;
            StringBuilder menuString = new StringBuilder("[");
            var rootPath = System.Configuration.ConfigurationManager.AppSettings["rootPath"];
            rootPath = rootPath == null ? "" : rootPath;
            menuString.Append("  { \"open\": \"true\",\"id\":\"1\", \"parentId\":\"0\", \"name\":\"系统菜单\", \"isParent\": \"true\",\"backgroundPosition\":\"0px - 80px\",\"img\":\"./ skin / topIcons / icon01.png\"},");
            //menuString.Append("{ \"id\":\"2\", \"parentId\":\"1\", \"name\":\"录入信息\",\"url\":\"/Epidemic/edit\", \"target\":\"frmright\",\"icon\": \"./skin/nav_icon_bg.png\",\"backgroundPosition\":\"0px - 128px\"},");
            menuString.Append("{ \"id\":\"3\", \"parentId\":\"1\", \"name\":\"全部人员列表\",\"url\":\"/Epidemic/index\", \"target\":\"frmright\",\"icon\": \"./skin/nav_icon_bg.png\",\"backgroundPosition\":\"0px - 128px\"},");
            menuString.Append("{ \"id\":\"5\", \"parentId\":\"1\", \"name\":\"管控人员列表\",\"url\":\"/Epidemic/chargeManList\", \"target\":\"frmright\",\"icon\": \"./skin/nav_icon_bg.png\",\"backgroundPosition\":\"0px - 128px\"},");
            if (IsSupAdmin)
            {
                menuString.Append("{ \"id\":\"4\", \"parentId\":\"1\", \"name\":\"管理员列表\",\"url\":\"/Epidemic/adminList\", \"target\":\"frmright\",\"icon\": \"./skin/nav_icon_bg.png\",\"backgroundPosition\":\"0px - 128px\"}");
            }
            //menuString.Append("{ \"id\":\"4\", \"parentId\":\"1\", \"name\":\"上报数据\",\"url\":\"/Epidemic/index\", \"target\":\"frmright\",\"icon\": \"./skin/nav_icon_bg.png\",\"backgroundPosition\":\"0px - 128px\"}");
            menuString.Append("]");
            return menuString.ToString();
        }



        public ActionResult Index()
        {
            //数据库查询
            //var obj = new DapperHelper();
            //var res = obj.Query<tb_user>("select * from tb_user");

            ////序列化
            //var str = JSONSerializer.Serialize(res);
            ViewBag.listTree = LoadData();
            return View();
        }
    }

    public class tb_user
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}