using EIP.Models;
using EIP.Models.GenericRepository;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class BulletinBoardController : Controller
    {
        dbEIPEntities db = new dbEIPEntities();
        EIPRepository<佈告欄> er = new EIPRepository<佈告欄>();
        // GET: BulletinBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BulletinBoard()
        {
            return View();
        }


        // 佈告欄總表
        public JsonResult BulletinBoardList()
        {
            var 佈告欄 = (from b in db.佈告欄
                        orderby b.佈告欄ID descending
                        select new
                        {
                            佈告欄ID = b.佈告欄ID,
                            EmployeeID = b.EmployeeID,
                            中文姓名 = b.中文姓名,
                            佈告欄標題 = b.佈告欄標題,
                            佈告欄內容 = b.佈告欄內容,
                            發布日期 = b.發布日期,
                            總比數 = db.佈告欄.Count()
                        }).ToList();

            return Json(佈告欄.Take(10), JsonRequestBehavior.AllowGet);
        }


        // 新增佈告欄
        public JsonResult CreateBulletinBoard(BulletinBoardViewModel CBB)
        {
            佈告欄 BB = new 佈告欄()
            {
                EmployeeID = Convert.ToInt32(Request.Cookies["AutoLg"]["id"]),
                中文姓名 = Server.UrlDecode(Request.Cookies["AutoLg"]["Name"]),
                佈告欄標題 = CBB.佈告欄標題,
                佈告欄內容 = CBB.佈告欄內容,
                發布日期 = CBB.發布日期,
            };
            er.Create(BB);
            return Json(BB, JsonRequestBehavior.AllowGet);
        }


        // 搜尋指定佈告欄

        [HttpGet]
        public JsonResult SearchOneBulletinBoard(int id)
        {
            佈告欄 sobb = db.佈告欄.FirstOrDefault(m=>m.佈告欄ID==id);
            BulletinBoardViewModel bb = new BulletinBoardViewModel
            {
                佈告欄ID = sobb.佈告欄ID,
                EmployeeID = sobb.EmployeeID,
                中文姓名 = sobb.中文姓名,
                佈告欄標題 = sobb.佈告欄標題,
                佈告欄內容 = sobb.佈告欄內容,
                發布日期 = sobb.發布日期
            };
            return Json(bb, JsonRequestBehavior.AllowGet);
        }

        // 修改佈告欄

        [HttpPost]
        public JsonResult BulletinBoardEdit(BulletinBoardViewModel bbvm)
        {
            佈告欄 bb = new 佈告欄()
            {
                佈告欄ID = bbvm.佈告欄ID,
                EmployeeID = bbvm.EmployeeID,
                中文姓名 = bbvm.中文姓名,
                佈告欄標題 = bbvm.佈告欄標題,
                佈告欄內容 = bbvm.佈告欄內容,
                發布日期 = bbvm.發布日期
            };
            er.Update(bb);
            return Json(bb, JsonRequestBehavior.AllowGet);
        }


        // 刪除佈告欄

        [HttpGet]
        public JsonResult BulletinBoardDelete(int id)
        {
            佈告欄 bb = db.佈告欄.Find(id);
            er.Delete(id);
            return Json(bb, JsonRequestBehavior.AllowGet);
        }


        // 搜尋佈告欄
        public JsonResult BulletinBoardSearch(string name)
        {

            var bb = from b in db.佈告欄
                     select b;
            if (!String.IsNullOrEmpty(name))
            {
                bb = bb.Where(a => a.中文姓名.Contains(name)||a.佈告欄標題.Contains(name)||a.發布日期.ToString().Contains(name));
            }
            return Json(bb.ToList().Take(10), JsonRequestBehavior.AllowGet);
        }

        // 佈告欄分頁方法
        public JsonResult BBPage(int arrow)
        {

            var bb = from b in db.佈告欄
                     orderby b.佈告欄ID descending
                      select new BulletinBoardViewModel
                      {
                          佈告欄ID = b.佈告欄ID,
                          EmployeeID = b.EmployeeID,
                          中文姓名 = b.中文姓名,
                          佈告欄標題 = b.佈告欄標題,
                          佈告欄內容 = b.佈告欄內容,
                          發布日期 = b.發布日期
                      };
            var bbvm = bb.Skip((arrow - 1) * 10).Take(10);
            return Json(bbvm, JsonRequestBehavior.AllowGet);
        }


        // ---------------------------以下Fullcalendar方法----------------------------//

        public JsonResult GetEvents()
        {
            using (dbEIPEntities db = new dbEIPEntities())
            {
                var events = db.行事曆.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(行事曆 e)
        {
            var status = false;
            using (dbEIPEntities db = new dbEIPEntities())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = db.行事曆.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    db.行事曆.Add(e);
                }

                db.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (dbEIPEntities db = new dbEIPEntities())
            {
                var v = db.行事曆.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    db.行事曆.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}