using EIP.Models;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class DDDDDController : Controller
    {
        dbEIPEntities db = new dbEIPEntities();
        // GET: DDDDD
        public ActionResult Index()
        {
            return View();
        }

        //=============================新增=============================//
        public ActionResult AskFor()
        {
            return View();
        }

        public string AskForAjax(請假細項 k)  //
        {
            請假細項 a = new 請假細項()
            {
                EmployeeID = k.EmployeeID,
                信箱 = k.信箱,
                部門 = k.部門,
                假別ID = k.假別ID,
                請假時數 = (int)k.請假時數,
                開始日期 = k.開始日期,
                結束日期 = k.結束日期,
                申請日期 = k.申請日期,
                中文姓名 = k.中文姓名,
                職稱 = k.職稱,
                請假班別 = k.請假班別,
                代理人 = k.代理人,
                審核狀態 = k.審核狀態,
            };
            db.請假細項.Add(a);
            db.SaveChanges();
            return "ok";
        }
        //=============================總表=============================//
        public ActionResult AskforList()
        {
            return View();
        }
        public JsonResult AskForListAjax()
        {
            var leaveform = db.請假細項.ToList().
                            Select(m => new
                            {
                                申請表編號 = m.申請表編號,
                                EmployeeID = m.EmployeeID,
                                信箱 = m.信箱,
                                部門 = m.部門,
                                假別ID = m.假別ID,
                                請假時數 = (int)m.請假時數,
                                開始日期 = m.開始日期,
                                結束日期 = m.結束日期,
                                申請日期 = m.申請日期,
                                中文姓名 = m.中文姓名,
                                職稱 = m.職稱,
                                請假班別 = m.請假班別,
                                代理人 = m.代理人,
                                審核狀態 = m.審核狀態,
                                假別1 = m.假別.假別1
                            });
            return Json(leaveform, JsonRequestBehavior.AllowGet);
        }
        //=============================單筆詳細=============================//
        //public ActionResult FindSingleData()
        //{
        //    return View();
        //}
        //public JsonResult FindSingleDataAjax(int id)
        //{
        //    var mm = db.請假細項.Select(x => new
        //    {
        //        EmployeeID = x.EmployeeID,
        //        信箱 = x.信箱,
        //        部門 = x.部門,
        //        假別ID = x.假別ID,
        //        請假時數 = (int)x.請假時數,
        //        開始日期 = x.開始日期,
        //        結束日期 = x.結束日期,
        //        申請日期 = x.申請日期,
        //        中文姓名 = x.中文姓名,
        //        職稱 = x.職稱,
        //        請假班別 = x.請假班別,
        //        代理人 = x.代理人,
        //        審核狀態 = x.審核狀態,
        //        假別 = x.假別.假別1,                
        //    }).FirstOrDefault(C => C.EmployeeID == id);
        //    return Json(mm, JsonRequestBehavior.AllowGet);
        //}
        //=============================刪除=============================//
        public JsonResult DeleteData(int id)
        {
            var deleteuser = db.請假細項.FirstOrDefault(m => m.EmployeeID == id);
            db.請假細項.Remove(deleteuser);
            db.SaveChanges();
            return Json(deleteuser, JsonRequestBehavior.AllowGet);
        }
        //=============================修改=============================//
        public ActionResult UpdateData()
        {
            return View();
        }
        public JsonResult GetUpdateData(int? id)  //why
        {
            var mm = db.請假細項.Select(x => new
            {
                申請表編號 = x.申請表編號,
                EmployeeID = x.EmployeeID,
                信箱 = x.信箱,
                部門 = x.部門,
                假別ID = x.假別ID,
                請假時數 = (int)x.請假時數,
                開始日期 = x.開始日期,
                結束日期 = x.結束日期,
                申請日期 = x.申請日期,
                中文姓名 = x.中文姓名,
                職稱 = x.職稱,
                請假班別 = x.請假班別,
                代理人 = x.代理人,
                審核狀態 = x.審核狀態,
            }).FirstOrDefault(C => C.申請表編號 == id);
            return Json(mm, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateDataAjax(請假細項 mb)  //
        {
            //請假細項 dba = new 請假細項()
            //{
            //    EmployeeID = mb.EmployeeID,
            //    信箱 = mb.信箱,
            //    部門 = mb.部門,
            //    假別ID = mb.假別ID,
            //    請假時數 = (int)mb.請假時數,
            //    開始日期 = mb.開始日期,
            //    結束日期 = mb.結束日期,
            //    申請日期 = mb.申請日期,
            //    中文姓名 = mb.中文姓名,
            //    職稱 = mb.職稱,
            //    請假班別 = mb.請假班別,
            //    代理人 = mb.代理人,
            //    審核狀態 = mb.審核狀態,
            //};
            db.Entry<請假細項>(mb).State = EntityState.Modified;  //why
            db.SaveChanges();
            return Json(mb, JsonRequestBehavior.AllowGet);
        }

        //=============================加班=============================//

        public ActionResult OverTime()
        {
            return View();
        }
        public JsonResult OverTimeAjax(加班細項 n)
        {
            加班細項 k = new 加班細項()
            {
                加班表編號 = n.加班表編號,
                EmployeeID = n.EmployeeID,
                中文姓名 = n.中文姓名,
                部門 = n.部門,
                開始日期 = n.開始日期,
                結束日期 = n.結束日期,
                加班時數 = n.加班時數,
                已用可用 = n.已用可用,
                加班ID = n.加班ID,
                事由說明 = n.事由說明,
                主管簽核 = n.主管簽核
            };
            db.加班細項.Add(k);
            db.SaveChanges();
            return Json(k, JsonRequestBehavior.AllowGet);
        }

        //=============================加班總表=============================//

        public ActionResult OverTimeList()
        {

            return View();
        }
        public JsonResult OverTimeListAjax()
        {
            var test = db.加班細項.Select(m => new 
            {
                加班表編號 = m.加班表編號,
                EmployeeID = m.EmployeeID,
                中文姓名 = m.中文姓名,
                部門 = m.部門,
                開始日期 = m.開始日期,
                結束日期 = m.結束日期,
                加班時數 = m.加班時數,
                已用可用 = m.已用可用,
                加班ID = m.加班ID,
                事由說明 = m.事由說明,
                主管簽核 = m.主管簽核,
                加班類別 = m.加班別.加班類別
            });
            return Json(test, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteOverTimeData(int id)
        {
            var deletedata = db.加班細項.FirstOrDefault(m => m.加班表編號 == id);
            db.加班細項.Remove(deletedata);
            db.SaveChanges();
            return Json(deletedata, JsonRequestBehavior.AllowGet);
        }

        //=============================修改=============================//

        public ActionResult UpdateOverTime()
        {
            return View();
        }
        public JsonResult GetUpdateDataOverTime(int? id)  //抓到資料庫選取的那筆資料
        {

            var overtimeupdate = db.加班細項.Select(x => new     //左邊是自訂欄位右邊是資料庫欄位
            {
                加班表編號 = x.加班表編號,
                EmployeeID = x.EmployeeID,
                中文姓名 = x.中文姓名,
                部門 = x.部門,
                開始日期 = x.開始日期,
                結束日期 = x.結束日期,
                加班時數 = x.加班時數,
                已用可用 = x.已用可用,
                加班ID = x.加班ID,
                事由說明 = x.事由說明,
                主管簽核 = x.主管簽核,
                加班類別 = x.加班別.加班類別
            }).FirstOrDefault(C => C.加班表編號 == id); //關聯屬性要用匿名或ViewModel
            return Json(overtimeupdate, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult OverTimeUpdateAjax(加班細項 ovtvm)  //從前端修改存回後端
        {

            //加班細項 dba = new 加班細項()
            //{
            //    加班表編號 = ovtvm.加班表編號,
            //    EmployeeID = ovtvm.EmployeeID,
            //    中文姓名 = ovtvm.中文姓名,
            //    部門 = ovtvm.部門,
            //    開始日期 = ovtvm.開始日期,
            //    結束日期 = ovtvm.結束日期,
            //    加班時數 = ovtvm.加班時數,
            //    已用可用 = ovtvm.已用可用,
            //    加班ID = ovtvm.加班ID,
            //    事由說明 = ovtvm.事由說明,
            //    主管簽核 = ovtvm.主管簽核,
            //};

            //var test = db.加班細項.FirstOrDefault(m => m.加班表編號 == ovtvm.加班表編號);
            //test.EmployeeID = ovtvm.EmployeeID;
            //test.中文姓名 = ovtvm.中文姓名;
            //test.部門 = ovtvm.部門;
            //test.開始日期 = ovtvm.開始日期;
            //test.結束日期 = ovtvm.結束日期;
            //test.加班時數 = ovtvm.加班時數;
            //test.已用可用 = ovtvm.已用可用;
            //test.加班ID = ovtvm.加班ID;
            //test.事由說明 = ovtvm.事由說明;
            //test.主管簽核 = ovtvm.主管簽核;

            db.Entry<加班細項>(ovtvm).State = EntityState.Modified;  //自動比對主索引鍵並覆蓋
            db.SaveChanges();
            return Json(ovtvm, JsonRequestBehavior.AllowGet);
        }
    }
}