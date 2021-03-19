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
    public class ProjectController : Controller
    {
        // GET: Project

        dbEIPEntities dbEIP = new dbEIPEntities();

        

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EmpIndex()
        {
           


            return View();
        }


        public ActionResult EmpIndexemp()
        {



            return View();
        }





        public JsonResult PJShowEdit()
        {
            var pjm = from p in dbEIP.eipProjectDetail
                      
                      select new ProjectListViewModel

                      {
                          專案編號 = p.pjId,
                          專案名稱 = p.pjName,
                          負責人 = p.pjManager,
                          專案建立日期 = p.pjDate,
                          預算 = p.pjPV預算,
                          初審審核結果 = (int)p.pjReviewAcceptOrNot1,
                          初審審核意見 = p.pjReviewAdvise1,
                          //員工編號 = (int)p.projectTeam.employeeID,
                          實際成本 = p.pjAC實際成本,
                          審核階段 = (int)p.pjReviewLevel,
                          //專案人數 = (int)p.projectTeam.pj人數,
                          //專案個人工作 = p.projectTeam.pj工作內容,
                          專案內容 = p.pjContent專案內容,
                          //專案團隊 = p.pjTeam,
                          專案工作項目 = p.pj項目,
                          //工作內容 = p.projectTeam.pjJob,
                          //工作時間 = (int)p.projectTeam.pj工作時間,
                          廠商投標金額 = (int)p.pj廠商投標金額,
                          淨利 = p.pjEV淨利,
                          終審審核意見 = p.pjReviewAdvise3,
                          終審審核結果 = (int)p.pjReviewAcceptOrNot3,
                          //結束時間 = (int)p.projectTeam.pj結束時間,
                          複審審核意見 = p.pjReviewAdvise2,
                          複審審核結果 = (int)p.pjReviewAcceptOrNot2,
                          //開始時間 = (int)p.projectTeam.pj開始時間
                      };




            return Json(pjm, JsonRequestBehavior.AllowGet);
        }


        public JsonResult PJShowEditlv0()
        {
            var pjm = from p in dbEIP.eipProjectDetail
                      where p.pjReviewAcceptOrNot1 == 0
                      select new ProjectListViewModel

                      {
                          專案編號 = p.pjId,
                          專案名稱 = p.pjName,
                          負責人 = p.pjManager,
                          專案建立日期 = p.pjDate,
                          預算 = p.pjPV預算,
                          初審審核結果 = (int)p.pjReviewAcceptOrNot1,
                          初審審核意見 = p.pjReviewAdvise1,
                          //員工編號 = (int)p.projectTeam.employeeID,
                          實際成本 = p.pjAC實際成本,
                          審核階段 = (int)p.pjReviewLevel,
                          //專案人數 = (int)p.projectTeam.pj人數,
                          //專案個人工作 = p.projectTeam.pj工作內容,
                          專案內容 = p.pjContent專案內容,
                          //專案團隊 = p.pjTeam,
                          專案工作項目 = p.pj項目,
                          //工作內容 = p.projectTeam.pjJob,
                          //工作時間 = (int)p.projectTeam.pj工作時間,
                          廠商投標金額 = (int)p.pj廠商投標金額,
                          淨利 = p.pjEV淨利,
                          終審審核意見 = p.pjReviewAdvise3,
                          終審審核結果 = (int)p.pjReviewAcceptOrNot3,
                          //結束時間 = (int)p.projectTeam.pj結束時間,
                          複審審核意見 = p.pjReviewAdvise2,
                          複審審核結果 = (int)p.pjReviewAcceptOrNot2,
                          //開始時間 = (int)p.projectTeam.pj開始時間
                      };




            return Json(pjm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PJShowEditlv1()
        {
            var pjm = from p in dbEIP.eipProjectDetail
                      where p.pjReviewAcceptOrNot1 == 1
                      select new ProjectListViewModel
                      
                      {
                          專案編號 = p.pjId,
                          專案名稱 = p.pjName,
                          負責人 = p.pjManager,
                          專案建立日期 = p.pjDate,
                          預算 = p.pjPV預算,
                          初審審核結果 = (int)p.pjReviewAcceptOrNot1,
                          初審審核意見 = p.pjReviewAdvise1,
                          //員工編號 = (int)p.projectTeam.employeeID,
                          實際成本 = p.pjAC實際成本,
                          審核階段 = (int)p.pjReviewLevel,
                          //專案人數 = (int)p.projectTeam.pj人數,
                          //專案個人工作 = p.projectTeam.pj工作內容,
                          專案內容 = p.pjContent專案內容,
                          //專案團隊 = p.pjTeam,
                          專案工作項目 = p.pj項目,
                           //工作內容 = p.projectTeam.pjJob,
                          //工作時間 = (int)p.projectTeam.pj工作時間,
                          廠商投標金額 = (int)p.pj廠商投標金額,
                          淨利 = p.pjEV淨利,
                          終審審核意見 = p.pjReviewAdvise3,
                          終審審核結果 = (int)p.pjReviewAcceptOrNot3,
                          //結束時間 = (int)p.projectTeam.pj結束時間,
                          複審審核意見 = p.pjReviewAdvise2,
                          複審審核結果 = (int)p.pjReviewAcceptOrNot2,
                          //開始時間 = (int)p.projectTeam.pj開始時間
                      };




            return Json(pjm , JsonRequestBehavior.AllowGet);
        }

        public JsonResult PJShowEditlv2()
        {
            var pjm = from p in dbEIP.eipProjectDetail
                      where p.pjReviewAcceptOrNot2 == 1
                      select new ProjectListViewModel

                      {
                          專案編號 = p.pjId,
                          專案名稱 = p.pjName,
                          負責人 = p.pjManager,
                          專案建立日期 = p.pjDate,
                          預算 = p.pjPV預算,
                          初審審核結果 = (int)p.pjReviewAcceptOrNot1,
                          初審審核意見 = p.pjReviewAdvise1,
                          //員工編號 = (int)p.projectTeam.employeeID,
                          實際成本 = p.pjAC實際成本,
                          審核階段 = (int)p.pjReviewLevel,
                          //專案人數 = (int)p.projectTeam.pj人數,
                          //專案個人工作 = p.projectTeam.pj工作內容,
                          專案內容 = p.pjContent專案內容,
                          //專案團隊 = p.pjTeam,
                          專案工作項目 = p.pj項目,
                          //工作內容 = p.projectTeam.pjJob,
                          //工作時間 = (int)p.projectTeam.pj工作時間,
                          廠商投標金額 = (int)p.pj廠商投標金額,
                          淨利 = p.pjEV淨利,
                          終審審核意見 = p.pjReviewAdvise3,
                          終審審核結果 = (int)p.pjReviewAcceptOrNot3,
                          //結束時間 = (int)p.projectTeam.pj結束時間,
                          複審審核意見 = p.pjReviewAdvise2,
                          複審審核結果 = (int)p.pjReviewAcceptOrNot2,
                          //開始時間 = (int)p.projectTeam.pj開始時間
                      };




            return Json(pjm, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult PJEditDetail(int id)
        {
            eipProjectDetail ProjectEdit = dbEIP.eipProjectDetail.Find(id);
            ProjectListViewModel PLV = new ProjectListViewModel
            {
                專案編號 = ProjectEdit.pjId,
                專案名稱 = ProjectEdit.pjName,
                負責人 = ProjectEdit.pjManager,
                專案建立日期 = ProjectEdit.pjDate,
                預算 = ProjectEdit.pjPV預算,
                初審審核結果 = (int)ProjectEdit.pjReviewAcceptOrNot1,
                初審審核意見 = ProjectEdit.pjReviewAdvise1,
                //員工編號 = (int)ProjectEdit.projectTeam.employeeID,
                實際成本 = ProjectEdit.pjAC實際成本,
                審核階段 = (int)ProjectEdit.pjReviewLevel,
                //專案人數 = (int)ProjectEdit.projectTeam.pj人數,
                //專案個人工作 = ProjectEdit.projectTeam.pj工作內容,
                專案內容 = ProjectEdit.pjContent專案內容,
           /*     專案團隊 = ProjectEdit.pjTeam/**/
                專案工作項目 = ProjectEdit.pj項目,
                //工作內容 = ProjectEdit.projectTeam.pjJob,
                //工作時間 = (int)ProjectEdit.projectTeam.pj工作時間,
                廠商投標金額 = (int)ProjectEdit.pj廠商投標金額,
                淨利 = ProjectEdit.pjEV淨利,
                終審審核意見 = ProjectEdit.pjReviewAdvise3,
                終審審核結果 = (int)ProjectEdit.pjReviewAcceptOrNot3,
                //結束時間 = (int)ProjectEdit.projectTeam.pj結束時間,
                複審審核意見 = ProjectEdit.pjReviewAdvise2,
                複審審核結果 = (int)ProjectEdit.pjReviewAcceptOrNot2,
                //開始時間 = (int)ProjectEdit.projectTeam.pj開始時間

            };



            return Json(PLV, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public JsonResult PJEditDetail(ProjectListViewModel PJet)
        {
            

            eipProjectDetail epj = new eipProjectDetail()
            {
                pjId = PJet.專案編號,
                pjName = PJet.專案名稱,
                pjManager = PJet.負責人,
                pjDate = PJet.專案建立日期,
                pjPV預算 = PJet.預算,
                pjReviewAcceptOrNot1 = (int)PJet.初審審核結果,
                pjReviewAdvise1 = PJet.初審審核意見,
                pjAC實際成本 = PJet.實際成本,
                pjReviewLevel = (int)PJet.審核階段,
                pjContent專案內容 = PJet.專案內容,
                //pjTeam = PJet.專案團隊,
                pj項目 = PJet.專案工作項目,
                pj廠商投標金額 = (int)PJet.廠商投標金額,
                pjEV淨利 = PJet.淨利,
                pjReviewAdvise3 = PJet.終審審核意見,
                pjReviewAcceptOrNot3 = (int)PJet.終審審核結果,
                pjReviewAdvise2 = PJet.複審審核意見,
                pjReviewAcceptOrNot2 = (int)PJet.複審審核結果,
            };


            dbEIP.Entry<eipProjectDetail>(epj).State = EntityState.Modified;
            dbEIP.SaveChanges();
            return Json(epj,JsonRequestBehavior.AllowGet);


        }
        [HttpPost]

        public JsonResult PJEditTeam(ProjectListViewModel PJet)
        {
            projectTeam pt = new projectTeam()
            {
                pjTeam = PJet.專案團隊,
                employeeID = PJet.員工編號,
                pj人數 = PJet.專案人數,
                pj工作內容 = PJet.專案個人工作,
                pj工作時間 = (int)PJet.工作時間,
                pj結束時間 = (int)PJet.結束時間,
                pj開始時間 = (int)PJet.開始時間,
                pjJob = PJet.工作內容,
            };

            dbEIP.Entry<projectTeam>(pt).State = EntityState.Modified;
            dbEIP.SaveChanges();
            return Json(pt, JsonRequestBehavior.AllowGet);
        }


        public JsonResult PJAddDetail(ProjectListViewModel PJet)
        {


            eipProjectDetail epj = new eipProjectDetail()
            {
                pjId = PJet.專案編號,
                pjName = PJet.專案名稱,
                pjManager = PJet.負責人,
                pjDate = DateTime.Now.ToString(),
                pjPV預算 = PJet.預算,
                pjReviewAcceptOrNot1 = (int)PJet.初審審核結果,
                pjReviewAdvise1 = PJet.初審審核意見,
                pjAC實際成本 = PJet.實際成本,
                pjReviewLevel = (int)PJet.審核階段,
                pjContent專案內容 = PJet.專案內容,
                //pjTeam = PJet.專案團隊,
                pj項目 = PJet.專案工作項目,
                pj廠商投標金額 = (int)PJet.廠商投標金額,
                pjEV淨利 = PJet.淨利,
                pjReviewAdvise3 = PJet.終審審核意見,
                pjReviewAcceptOrNot3 = (int)PJet.終審審核結果,
                pjReviewAdvise2 = PJet.複審審核意見,
                pjReviewAcceptOrNot2 = (int)PJet.複審審核結果,
            };


            dbEIP.eipProjectDetail.Add(epj);
            dbEIP.SaveChanges();
            return Json(epj, JsonRequestBehavior.AllowGet);
           

        }


        public JsonResult PJAddTeam(ProjectListViewModel PJet)
        {
            projectTeam pt = new projectTeam()
            {
                pjTeam = PJet.專案團隊,
                employeeID = PJet.員工編號,
                pj人數 = PJet.專案人數,
                pj工作內容 = PJet.專案個人工作,
                pj工作時間 = (int)PJet.工作時間,
                pj結束時間 = (int)PJet.結束時間,
                pj開始時間 = (int)PJet.開始時間,
                pjJob = PJet.工作內容,
            };

            dbEIP.projectTeam.Add(pt);
            dbEIP.SaveChanges();
            return Json(pt, JsonRequestBehavior.AllowGet);
       
        }
















    }
}