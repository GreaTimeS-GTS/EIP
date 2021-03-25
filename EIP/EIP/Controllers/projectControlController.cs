using EIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class projectControlController : Controller
    {
        // GET: projectControl
        //public ActionResult Index()
        //{
        //    return View();
        //}



        dbEIPEntities db = new dbEIPEntities();



        public ActionResult pjView()
        {
            return View();
        }


        //找所有專案資料from總表
        public JsonResult getMainData()
        {
            var pjMainData = db.pj總表.Select(m => new
            {
                pjId = m.pjId,
                pjName = m.pjName,
                pjManager = m.pjManager,
                pj簡介 = m.pj建立.pj簡介,
                pj成員數 = m.pj建立.pj成員數,
            });
            return Json(pjMainData, JsonRequestBehavior.AllowGet);
        }
   


        //總表 有View
    public ActionResult showProjectList()
        {
            return View();
        }



        //成員回報日誌 有View
        public ActionResult dailyReport()
        {
            return View();
        }



        //找一筆專案資料from總表
        public JsonResult getMainData1(int id)
        {
            var pjMainData1 = db.pj總表.FirstOrDefault(m => m.pjId == id);
            var k = db.pj建立.FirstOrDefault(n => n.pjCreateId == pjMainData1.pjCreateId);
            var qPjData = new
            {
                pjId = pjMainData1.pjId,
                pjName = pjMainData1.pjName,
                pjManager = pjMainData1.pjManager,
                pj成員數 = k.pj成員數,
            };
            return Json(qPjData, JsonRequestBehavior.AllowGet);
        }


    }
}