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
    public class theProjectController : Controller
    {
        // GET: theProject
        //public ActionResult Index()
        //{
        //    return View();
        //}


        dbEIPEntities dbEIP = new dbEIPEntities();
        public ActionResult pjView()
        {
            return View();
        }

        public JsonResult pjListFindData()
        {
            
            var qPjList = dbEIP.eipProjectDetail.Select(m => new
            {
                pjid = m.pjId,
                pjName = m.pjName,
                pjManager = m.pjManager,
                pjDate = m.pjDate,
                pjContent = m.pjContent專案內容,
                pjPv= m.pjPV預算,
                pjAc=m.pjAC實際成本,
                pjEv = m.pjEV淨利,
                pjReviewAcceptOrNot1 = m.pjReviewAcceptOrNot1,
                pjReviewAcceptOrNot2 = m.pjReviewAcceptOrNot2,
                pjReviewAcceptOrNot3 = m.pjReviewAcceptOrNot3,
                pjReviewLevel = m.pjReviewLevel,
                pjReviewAdvise1 = m.pjReviewAdvise1,
                pjReviewAdvise2 = m.pjReviewAdvise2,
                pjReviewAdvise3 = m.pjReviewAdvise3,
                pj廠商投標金額 = m.pj廠商投標金額,
                pjObject = m.pj項目   
            });

            return Json(qPjList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult pjListFindDataById(int id)
        {
            var qDetail = dbEIP.eipProjectDetail.FirstOrDefault(m => m.pjId == id);

            var qPjList = new
            {
                pjid = qDetail.pjId,
                pjName = qDetail.pjName,
                pjManager = qDetail.pjManager,
                pjDate = qDetail.pjDate,
                pjContent = qDetail.pjContent專案內容,
                pjPv = qDetail.pjPV預算,
                pjAc = qDetail.pjAC實際成本,
                pjEv = qDetail.pjEV淨利,
                pjReviewAcceptOrNot1 = qDetail.pjReviewAcceptOrNot1,
                pjReviewAcceptOrNot2 = qDetail.pjReviewAcceptOrNot2,
                pjReviewAcceptOrNot3 = qDetail.pjReviewAcceptOrNot3,
                pjReviewLevel = qDetail.pjReviewLevel,
                pjReviewAdvise1 = qDetail.pjReviewAdvise1,
                pjReviewAdvise2 = qDetail.pjReviewAdvise2,
                pjReviewAdvise3 = qDetail.pjReviewAdvise3,
                pj廠商投標金額 = qDetail.pj廠商投標金額,
                pjObject = qDetail.pj項目
            };

            return Json(qPjList, JsonRequestBehavior.AllowGet);
        }





        public JsonResult pjDailyReport(int id)
        {
            var qDetail = dbEIP.projectTeam.FirstOrDefault(m => m.pjId == id);         
            var pjDailyReport = new
            {
                pjDailyReport = qDetail.pjDailyReport,
                pjTeam = qDetail.pjTeam,
                pjId = qDetail.pjId,
                employeeID = qDetail.employeeID,
                pjJob = qDetail.pjJob,
                pj人數 = qDetail.pj人數,
                pj開始時間 = qDetail.pj開始時間,
                pj結束時間 = qDetail.pj結束時間,
                pj工作內容 = qDetail.pj工作內容,
                pj工作時間 = qDetail.pj工作時間,
                pj填表日期 = qDetail.pj填表日期
            };

            return Json(pjDailyReport, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]

        public JsonResult PJEditTeam(projectTeam pj)
        {
            var pjj = new projectTeam()
            {
                pjDailyReport = pj.pjDailyReport,
                pjTeam = pj.pjTeam,
                pjId = pj.pjId,
                employeeID = Convert.ToInt32(Request.Cookies["AutoLg"]["id"]),
                pjJob = pj.pjJob,
                pj人數 = pj.pj人數,
                pj開始時間 = (int)pj.pj開始時間,
                pj結束時間 = (int)pj.pj結束時間,
                pj工作內容 = pj.pj工作內容,
                pj工作時間 = (int)pj.pj工作時間,
                pj填表日期 = DateTime.Now.ToString()
            };

            //dbEIP.Entry(pjj).State = EntityState.Modified;
            dbEIP.projectTeam.Add(pjj);
            dbEIP.SaveChanges();
            return Json(pjj, JsonRequestBehavior.AllowGet);
        }



        public JsonResult pjFindRecord()
        {

            var pjRecord = dbEIP.projectTeam.Select(m => new
            {
                pjDailyReport = m.pjDailyReport,
                pjTeam = m.pjTeam,
                pjId = m.pjId,
                employeeID = m.employeeID,
                pjJob = m.pjJob,
                pj人數 = m.pj人數,
                pj開始時間 = m.pj開始時間,
                pj結束時間 = m.pj結束時間,
                pj工作內容 = m.pj工作內容,
                pj工作時間 = m.pj工作時間,
                pj填表日期 = m.pj填表日期
            });



            return Json(pjRecord, JsonRequestBehavior.AllowGet);
        }



    }
}