using EIP.Models.ViewModel;
using EIP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class HomeController : Controller
    {
        dbEIPEntities db = new dbEIPEntities();

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
        public JsonResult AccPwCheck(LoginViewModel LoginVM)
        {
            var x = new
            {
                信箱 = LoginVM.信箱,
                EmployeePW = LoginVM.EmployeePW,
                記住我 = LoginVM.RememberMe
            };


            var mmb = db.個人資料.FirstOrDefault(m => m.信箱 == x.信箱 && m.EmployeePW == x.EmployeePW);
            if (mmb == null)
            {
                Response.Cookies["AutoLg"].Expires = DateTime.Now.AddDays(-1);
                return Json(new { status = "" }, JsonRequestBehavior.AllowGet);
            }

            if (mmb != null)
            {
                Response.Cookies["AutoLg"]["id"] = mmb.EmployeeID.ToString();
                Response.Cookies["AutoLg"]["Name"] = Server.UrlEncode(mmb.中文姓名);
                Response.Cookies["AutoLg"]["Auth"] = Server.UrlEncode(mmb.職稱);
                if (LoginVM.RememberMe)
                {
                    Response.Cookies["AutoLg"].Expires = DateTime.Now.AddDays(30);
                }
            }
            return Json(mmb, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            Response.Cookies["AutoLg"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login", "Home");
        }
        [HttpGet]
        public JsonResult MyProfile()
        {
            個人資料 UserProfile = db.個人資料.Find(Convert.ToInt32(Request.Cookies["AutoLg"]["id"]));
            var mvm = new 
            {
                中文姓名 = UserProfile.中文姓名,
                英文姓名 = UserProfile.英文姓名,
                性別 = UserProfile.性別,
                EmployeeID = UserProfile.EmployeeID,
                出生年月日 = UserProfile.出生年月日,
                受雇日期 = UserProfile.受雇日期,
                職稱 = UserProfile.職稱,
                部門 = UserProfile.部門,
                信箱 = UserProfile.信箱,
                電話 = UserProfile.電話,
                居住地 = UserProfile.居住地,
                婚姻狀況 = UserProfile.婚姻狀況,
                特休 = UserProfile.特休,
                薪資 = UserProfile.薪資,
                權限 = UserProfile.權限
            };
            return Json(mvm, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditPW(string pw)
        {
            int ID = Convert.ToInt32(Request.Cookies["AutoLg"]["id"]);
            db.個人資料.FirstOrDefault(x => x.EmployeeID == ID).EmployeePW = pw;    
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult HRShow()
        {
            return View();
        }
      
        public JsonResult HRShowEdit()
        {
         

            var qqm = (from m in db.個人資料
                      orderby m.EmployeeID descending
                      select new 
                      {   
                          EmployeePW = m.EmployeePW,
                          中文姓名 = m.中文姓名,
                          英文姓名 = m.英文姓名,
                          性別 = m.性別,
                          EmployeeID = m.EmployeeID,
                          出生年月日 = m.出生年月日,
                          受雇日期 = m.受雇日期,
                          職稱 = m.職稱,
                          部門 = m.部門,
                          信箱 = m.信箱,
                          電話 = m.電話,
                          居住地 = m.居住地,
                          婚姻狀況 = m.婚姻狀況,
                          特休 = m.特休,
                          薪資 = m.薪資,
                          權限 = m.權限,
                          總比數= db.個人資料.Count()                         
                      }).ToList();
            
            return Json(qqm.Take(10), JsonRequestBehavior.AllowGet);

        }

        [HttpGet]    
        public JsonResult HREditt(int id)
        {
            個人資料 EditProfile = db.個人資料.Find(id);
            var MVM = new 
            {
               
                EmployeePW = EditProfile.EmployeePW,
                中文姓名 = EditProfile.中文姓名,
                英文姓名 = EditProfile.英文姓名,
                性別 = EditProfile.性別,
                EmployeeID = EditProfile.EmployeeID,
                出生年月日 = EditProfile.出生年月日,
                受雇日期 = EditProfile.受雇日期,
                職稱 = EditProfile.職稱,
                部門 = EditProfile.部門,
                信箱 = EditProfile.信箱,
                電話 = EditProfile.電話,
                居住地 = EditProfile.居住地,
                婚姻狀況 = EditProfile.婚姻狀況,
                特休 = EditProfile.特休,
                薪資 = EditProfile.薪資,
                權限 = EditProfile.權限,
              
            };
            return Json(MVM, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult HREdit(個人資料 mlvm)
        {
         
            個人資料 mmb = new 個人資料()
            {
                EmployeePW = mlvm.EmployeePW,
                中文姓名 = mlvm.中文姓名,
                英文姓名 = mlvm.英文姓名,
                性別 = mlvm.性別,
                EmployeeID = mlvm.EmployeeID,
                出生年月日 = mlvm.出生年月日,
                受雇日期 = mlvm.受雇日期,
                職稱 = mlvm.職稱,
                部門 = mlvm.部門,
                信箱 = mlvm.信箱,
                電話 = mlvm.電話,
                居住地 = mlvm.居住地,
                婚姻狀況 = mlvm.婚姻狀況,
                特休 = mlvm.特休,
                薪資 = mlvm.薪資,
                權限 = mlvm.權限
            };
            db.Entry<個人資料>(mmb).State = EntityState.Modified;
            db.SaveChanges();
            return Json(mmb, JsonRequestBehavior.AllowGet);

        }

        public JsonResult HRAdd(個人資料 mlvm)
        {
            個人資料 mmb = new 個人資料()
            {
                EmployeePW = mlvm.EmployeePW,
                中文姓名 = mlvm.中文姓名,
                英文姓名 = mlvm.英文姓名,
                性別 = mlvm.性別,
                EmployeeID = mlvm.EmployeeID,
                出生年月日 = mlvm.出生年月日,
                受雇日期 = mlvm.受雇日期,
                職稱 = mlvm.職稱,
                部門 = mlvm.部門,
                信箱 = mlvm.信箱,
                電話 = mlvm.電話,
                居住地 = mlvm.居住地,
                婚姻狀況 = mlvm.婚姻狀況,
                特休 = mlvm.特休,
                薪資 = mlvm.薪資,
                權限 = mlvm.權限,
                狀態=mlvm.狀態
                
            };

            db.個人資料.Add(mmb);
            db.SaveChanges();
            return Json(mmb, JsonRequestBehavior.AllowGet);
            //return mlvm;
        }
        public JsonResult HRDelete(int id) {
            個人資料 mlvm = db.個人資料.Find(id);
            db.個人資料.Remove(mlvm);
            //mlvm.狀態 = "不在職";
            //db.Entry<個人資料>(mlvm).State = EntityState.Modified;
            db.SaveChanges();
            return Json(mlvm, JsonRequestBehavior.AllowGet);
        }
        public JsonResult HRSearch(string name)
        {
            var mlvm = from m in db.個人資料
                       where (m.中文姓名.Contains(name))
                       orderby m.EmployeeID descending
                       select m;
            return Json(mlvm.Take(10), JsonRequestBehavior.AllowGet);
        }

        public JsonResult HRPage(int arrow) {

            var qqm = from m in db.個人資料
                      orderby m.EmployeeID descending
                      select new 
                      {
                          EmployeePW = m.EmployeePW,
                          中文姓名 = m.中文姓名,
                          英文姓名 = m.英文姓名,
                          性別 = m.性別,
                          EmployeeID = m.EmployeeID,
                          出生年月日 = m.出生年月日,
                          受雇日期 = m.受雇日期,
                          職稱 = m.職稱,
                          部門 = m.部門,
                          信箱 = m.信箱,
                          電話 = m.電話,
                          居住地 = m.居住地,
                          婚姻狀況 = m.婚姻狀況,
                          特休 = m.特休,
                          薪資 = m.薪資,
                          權限 = m.權限
                      };
            var mlvm = qqm.Skip((arrow - 1) * 10).Take(10);
            return Json(mlvm, JsonRequestBehavior.AllowGet);
        }
    }
}