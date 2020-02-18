using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SeatManage.SeatManageComm;

namespace SeatManageWebQUI.Controllers
{
    public class EpidemicController : BaseController
    {
        // GET: list
        public ActionResult Index()
        {
            string gridData = QueryUserInfo(new com.gxchuwei.Model.PersonInfo());
            ViewBag.tbData = gridData;
            return View();
        }

        public string QueryUserInfo(com.gxchuwei.Model.PersonInfo param)
        {
            com.gxchuwei.BLL.PersonInfo bll=  new com.gxchuwei.BLL.PersonInfo();
            var where = "(isadmin <> '1' or isadmin is null)";
            if (!IsSupAdmin)
            {
                where += " and ManageMan = '" + LoginId + "'";
            }
            List<com.gxchuwei.Model.PersonInfo> userlist = bll.GetModelList(where);
            userlist = userlist.OrderByDescending(x => x.ID).ToList();
            if (!string.IsNullOrEmpty(param.PersonName))
            {
                userlist = userlist.Where(x => x.PersonName.Contains(param.PersonName)).ToList();
            }
            if (!string.IsNullOrEmpty(param.IDCardNo))
            {
                userlist = userlist.Where(x => x.IDCardNo.Contains(param.IDCardNo)).ToList();
            }
            if (!string.IsNullOrEmpty(param.NowAddress))
            {
                userlist = userlist.Where(x => x.NowAddress.Contains(param.NowAddress)).ToList();
            }
            if (!string.IsNullOrEmpty(param.PersonType))
            {
                userlist = userlist.Where(x => x.PersonType.Contains(param.PersonType)).ToList();
            }
            if (!string.IsNullOrEmpty(param.Area))
            {
                userlist = userlist.Where(x => x.Area.Contains(param.Area)).ToList();
            }
            if (!string.IsNullOrEmpty(param.DisposeType))
            {
                userlist = userlist.Where(x => x.DisposeType.Contains(param.DisposeType)).ToList();
            }
            if (!string.IsNullOrEmpty(param.ManageMan))
            {
                userlist = userlist.Where(x => x.ManageMan.Contains(param.ManageMan)).ToList();
            }
            
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"form.paginate.pageNo\": 1,");
            sb.Append("\"form.paginate.totalRows\": " + userlist.Count.ToString() + ",");
            sb.Append("	\"rows\": ");
            foreach (com.gxchuwei.Model.PersonInfo item in userlist)
            {
                if (item.LastTempDate.HasValue && item.LastTemp.HasValue)
                { 
                    string css = "";
                    if (("咳嗽、发热、乏力").Contains(item.PhysicalState) && (double)item.LastTemp.Value > 37.2)
                    {
                        css = "color: #FF0000;";
                    }
                    item.LastTempStr = "<div class='tdContentStyle4' style='"+css+"'>" + item.PhysicalState + "（" + item.LastTemp.Value.ToString() + "°C" + @"）<br//\> " + item.LastTempDate.Value.ToString("yyyy -MM-dd") + "</div>";
                }
                else item.LastTempStr = "";
                if (item.ArriveTime.HasValue)
                    item.ArriveTimeStr = item.ArriveTime.Value.ToString("yyyy-MM-dd");
                else item.ArriveTimeStr = "";
            }
            sb.Append(JSONSerializer.Serialize(userlist));
            //sb.Remove(sb.Length - 1, 1);
            sb.Append("}");
            string data = sb.ToString();
            return data;
        }

        public ActionResult DayInfoList(int ID)
        {
            string gridData = DayInfoData(ID);
            ViewBag.tbData = gridData;
            ViewBag.ID = ID;
            com.gxchuwei.Model.PersonInfo person = new com.gxchuwei.Model.PersonInfo();
            com.gxchuwei.BLL.PersonInfo bll = new com.gxchuwei.BLL.PersonInfo();
            person = bll.GetModel(ID);
            return View(person);
        }

        public string DayInfoData(int ID)
        {
            com.gxchuwei.BLL.PersonRecord bll = new com.gxchuwei.BLL.PersonRecord();
            var list = new List<com.gxchuwei.Model.PersonRecord>();
            list = bll.GetModelList(" PersonID = " + ID.ToString()).OrderByDescending(x=>x.DeclarationTime).ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"form.paginate.pageNo\": 1,");
            sb.Append("\"form.paginate.totalRows\": 100,");
            sb.Append("	\"rows\": ");
            sb.Append(JSONSerializer.Serialize(list));
            sb.Append("}");
            string data = sb.ToString();
            return data;
        }
        
        public ActionResult Edit(int ID = 0)
        {
            if (IsSupAdmin)
            {
                ViewBag.IsSupAdmin = "1";
            }
            com.gxchuwei.Model.PersonInfo person = new com.gxchuwei.Model.PersonInfo();
            if (ID > 0)
            {
                com.gxchuwei.BLL.PersonInfo bll = new com.gxchuwei.BLL.PersonInfo();
                person = bll.GetModel(ID);
            }
            return View(person);
        }

        [HttpPost]
        public JsonResult SaveEdit(com.gxchuwei.Model.PersonInfo person)
        {
            JsonResult result = null;
            com.gxchuwei.BLL.PersonInfo personBll = new com.gxchuwei.BLL.PersonInfo();
            if (person.ID <= 0)
            {
                personBll.Add(person);
                result = Json(new { status = "yes", message = "添加成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var old = personBll.GetModel(person.ID);
                old.Area = person.Area;
                old.PersonName = person.PersonName;
                old.Sex = person.Sex;
                old.IDCardNo = person.IDCardNo;
                old.PhoneNo = person.PhoneNo;
                old.Native = person.Native;
                old.ArriveTime = person.ArriveTime;
                old.ArrivePurpose = person.ArrivePurpose;
                old.Traffic = person.Traffic;
                old.PhysicalState = person.PhysicalState;
                old.LastTemp = person.LastTemp;
                old.DisposeType = person.DisposeType;
                old.NowAddress = person.NowAddress;
                old.ManageMan = person.ManageMan;
                old.ManageManPhone = person.ManageManPhone;
                old.ByeondWarning = person.ByeondWarning;
                old.IsAdmin = person.IsAdmin;
                old.LoginName = person.LoginName;
                old.LoginPassword = person.LoginPassword;
                personBll.Update(person);
                result = Json(new { status = "yes", message = "添加成功" }, JsonRequestBehavior.AllowGet);
            }

            return result;
        }

        public JsonResult Delete(int ID)
        {
            if (!IsSupAdmin)
            {
                return Json(new { sus = 0, msg = "权限不足！" }, JsonRequestBehavior.AllowGet);
            }
            var cc = 0;
            com.gxchuwei.BLL.PersonInfo bll = new com.gxchuwei.BLL.PersonInfo();
            cc = bll.Delete(ID)?1:0;
            var msg = cc > 0 ? "删除成功！" : "删除成功！";
            var result = Json(new { sus = cc, msg = msg }, JsonRequestBehavior.AllowGet);
            return result;
        }


        public ActionResult adminList()
        {
            string gridData = QueryUserInfoAdmin(new com.gxchuwei.Model.PersonInfo());
            ViewBag.tbData = gridData;
            return View();
        }

        public string QueryUserInfoAdmin(com.gxchuwei.Model.PersonInfo param)
        {
            com.gxchuwei.BLL.PersonInfo bll = new com.gxchuwei.BLL.PersonInfo();
            var where = "isadmin = '1'";
            List<com.gxchuwei.Model.PersonInfo> userlist = bll.GetModelList(where);
            userlist = userlist.OrderByDescending(x => x.ID).ToList();
            if (!string.IsNullOrEmpty(param.PersonName))
            {
                userlist = userlist.Where(x => x.PersonName.Contains(param.PersonName)).ToList();
            }
            if (!string.IsNullOrEmpty(param.IDCardNo))
            {
                userlist = userlist.Where(x => x.IDCardNo.Contains(param.IDCardNo)).ToList();
            }
            if (!string.IsNullOrEmpty(param.PhoneNo))
            {
                userlist = userlist.Where(x => x.PhoneNo.Contains(param.PhoneNo)).ToList();
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"form.paginate.pageNo\": 1,");
            sb.Append("\"form.paginate.totalRows\": "+ userlist .Count.ToString()+ ",");
            sb.Append("	\"rows\": ");
            foreach (com.gxchuwei.Model.PersonInfo item in userlist)
            {
                if (item.LastTempDate.HasValue && item.LastTemp.HasValue)
                    item.LastTempStr = item.PhysicalState + "（" + item.LastTemp.Value.ToString() + "°C" + @"）<br//\> " + item.LastTempDate.Value.ToString("yyyy -MM-dd");
                else item.LastTempStr = "";
                if (item.ArriveTime.HasValue)
                    item.ArriveTimeStr = item.ArriveTime.Value.ToString("yyyy-MM-dd");
                else item.ArriveTimeStr = "";
            }
            sb.Append(JSONSerializer.Serialize(userlist));
            //sb.Remove(sb.Length - 1, 1);
            sb.Append("}");
            ViewBag.Count = userlist.Count;
            string data = sb.ToString();
            return data;
        }
    }
}