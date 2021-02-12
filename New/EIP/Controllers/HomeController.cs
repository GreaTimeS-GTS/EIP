using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EIP.Models;
using EIP.Models.ViewModel;


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

        public ActionResult PartialLayoutTop()
        {
            return PartialView();
        }

        public ActionResult PartialLayoutBodyLeft()
        {
            return PartialView();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddEmployee() {

            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(個人資料 dM)    //按下submit跳轉到的頁面
        {
            if (!ModelState.IsValid)
            {                    
                return View();
            }
            db.個人資料.Add(dM);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");   //跳轉到首頁
        }
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(LoginViewModel LoginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var mmb = db.個人資料.FirstOrDefault(m => m.信箱 == LoginVM.信箱 && m.EmployeePW == LoginVM.EmployeePW);
            if (mmb == null)
            {

                return View();
            }
            if (mmb != null)
            {
                Response.Cookies["AutoLg"]["id"] = mmb.EmployeeID.ToString();
                Response.Cookies["AutoLg"]["Name"] = Server.UrlEncode(mmb.中文姓名);
                if (LoginVM.RememberMe == "on")
                {
                    Response.Cookies["AutoLg"].Expires = DateTime.Now.AddDays(30);

                }
            }
            return RedirectToAction("About", "Home");
        }
    }
}