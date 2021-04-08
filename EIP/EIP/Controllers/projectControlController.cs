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
        //----------------------YOOOOOOO--------

        public JsonResult getPjProjectDatat2()
        {
            var pjm = from m in db.pjProject
                      where m.pj複審結果 == "不通過" || m.pj複審結果 == "待審核" && m.pj審核階段 == "複審"

                      select new
                      {
                          pjId = m.pjId,
                          pjName = m.pjName,
                          pj審核階段 = m.pj審核階段,
                          pj初審結果 = m.pj初審結果,
                          pjMemberCount = m.pjMemberCount,
                          pjManager = m.pjManager,
                      };
            return Json(pjm, JsonRequestBehavior.AllowGet);
        }
        //複審審核

        //初審審核
        public JsonResult getPjProjectDatat3()
        {
            var pjm = from m in db.pjProject
                      where m.pj初審結果 == "不通過" || m.pj初審結果 == "待審核" && m.pj審核階段 == "初審"
                      select new
                      {
                          pjId = m.pjId,
                          pjName = m.pjName,
                          pj審核階段 = m.pj審核階段,
                          pj初審結果 = m.pj初審結果,
                          pjMemberCount = m.pjMemberCount,
                          pjManager = m.pjManager,
                      };
            return Json(pjm, JsonRequestBehavior.AllowGet);
        }
        //初審審核

        //初審審核
        public JsonResult getPjProjectDatat4()
        {
            var pjm = from m in db.pjProject
                      where m.pj初審結果 == "通過" && m.pj審核階段 == "初審"
                      select new
                      {
                          pjId = m.pjId,
                          pjName = m.pjName,
                          pj審核階段 = m.pj審核階段,
                          pj初審結果 = m.pj初審結果,
                          pjMemberCount = m.pjMemberCount,
                          pjManager = m.pjManager,
                      };
            return Json(pjm, JsonRequestBehavior.AllowGet);
        }
        //初審審核


        public void getPjProjectDataFromIdto2(int id)
        {
            var d = db.pjProject.FirstOrDefault(m => m.pjId == id);
            {
                d.pj審核階段 = "複審";
                d.pj複審結果 = "待審核";
            }
            db.SaveChanges();
        }

        public void pj審核結果儲存(pjProject data)
        {
            db.Entry<pjProject>(data).State = EntityState.Modified; //整筆資料全部覆寫
            db.SaveChanges();
        }


        public void pj審核意見(pjAdvice ad)
        {
            var a = new pjAdvice

            {
                pjId = ad.pjId,
                pj意見內容 = ad.pj意見內容,
                pj審核階段 = ad.pj審核階段,
            };


            db.pjAdvice.Add(a);
            db.SaveChanges();
        }






        //---------- T E S T -----------------
        public void getCr8formVal(pjProject val)
        {
            var x = new pjProject
            {
                pjName = val.pjName,
                pjIntroduction = val.pjIntroduction,
                pjManager = val.pjManager,
                pjClient = val.pjClient,
                pjBudget = val.pjBudget,
                pjMemberCount = val.pjMemberCount,
                pj結束日期 = val.pj結束日期,
                pj開始日期 = val.pj開始日期,
                pj預估時間 = val.pj預估時間,
                pjManagerId = val.pjManagerId,
                pj初審結果 = val.pj初審結果,
                pj審核階段 = val.pj審核階段,
            };
            db.pjProject.Add(x);
            db.SaveChanges();
        }
        public JsonResult getPjProjectData()
        {
            var data = db.pjProject.Select(m => new
            {
                pjManager = m.pjManager,
                pjId = m.pjId,
                pjName = m.pjName,
                pj審核階段 = m.pj審核階段,
                pj初審結果 = m.pj初審結果,
                pjMemberCount = m.pjMemberCount,
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPjTeamDataFromId(int id)
        {
            var teamData = from cc in db.pjTeam
                    where cc.pjId == id
                    select cc;
            //var team = t.Where(s => s.pjId == d.pjId);
            return Json(teamData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPjTeamDataFromId個人(int id,string name)
        {
            var teamData = from cc in db.pjTeam
                           where cc.pjMemberName == name && cc.pjId == id
                           || cc.pjProject.pjManager == name && cc.pjId == id
                           select new
                           {
                               pjTeamId = cc.pjTeamId,
                               pjId = cc.pjId,
                               pjMemberId = cc.pjMemberId,
                               pjMemberName = cc.pjMemberName,
                               pjTarget = cc.pjTarget,
                               pjMember部門 = cc.pjMember部門,
                               pjTask = cc.pjTask,
                               pjFixedDuration = cc.pjFixedDuration,
                               pjTaskStartDate = cc.pjTaskStartDate,
                               pjTaskEndDate = cc.pjTaskEndDate,
                               pjName = cc.pjProject.pjName,
                               pjManager = cc.pjProject.pjManager,
                           };
            //var team = t.Where(s => s.pjId == d.pjId);
            return Json(teamData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPjProjectDataFromId(int id)
        {
            var d = db.pjProject.FirstOrDefault(m => m.pjId == id);            
            var getPjProjectDataFromId = new
            {
                pjId = d.pjId,
                pjName = d.pjName,
                pjManager = d.pjManager,
                pjBudget = d.pjBudget,
                pjIntroduction = d.pjIntroduction,
                pjMemberCount = d.pjMemberCount,
                pjClient = d.pjClient,
                pj初審結果 = d.pj初審結果,
                pj複審結果 = d.pj複審結果,
                pj開始日期 = d.pj開始日期,
                pj結束日期 = d.pj結束日期,
                pjManagerId = d.pjManagerId,
                pj預估時間 = d.pj預估時間,
                pj審核階段 = d.pj審核階段,             
            };
            return Json(getPjProjectDataFromId, JsonRequestBehavior.AllowGet);
        }
        public void savePreview2FormData(pjTeam formdata)
        {
            db.pjTeam.Add(formdata);
            db.SaveChanges();
        }
        //public void pj審核結果儲存(pjProject data)
        //{
        //    //db.Entry<pjProject>(data).State = EntityState.Modified; //整筆資料全部覆寫
        //    //db.SaveChanges();
        //}
        public JsonResult pj專案列表()
        {
            var pj專案列表Data = from x in db.pjProject
                             where x.pj初審結果 == "通過" && x.pj複審結果 == "通過"
                             //select new {
                             //    pjId = x.pjId,
                             //    pjName = x.pjName,
                             //    pjIntroduction = x.pjIntroduction,
                             //    pjManager = x.pjManager,
                             //};
                             select x;

                             
            return Json(pj專案列表Data, JsonRequestBehavior.AllowGet);
        }
        public void pj專案規劃(pjTeam formdata)
        {
            var x = db.pjTeam.FirstOrDefault(m => m.pjTeamId == formdata.pjTeamId);
            //db.Entry<pjTeam>(x).State = EntityState.Modified;
            x.pjMember部門 = formdata.pjMember部門;
            x.pjTask = formdata.pjTask;
            x.pjTaskStartDate = formdata.pjTaskStartDate;
            x.pjTaskEndDate = formdata.pjTaskEndDate;
            x.pjFixedDuration = formdata.pjFixedDuration;
            db.SaveChanges();
        }
        public void pj進度回報單(pjReport data)
        {
            var x = new pjReport
            {
                pjId = data.pjId,
                pjReportDate = data.pjReportDate,
                pjReportContent = data.pjReportContent,
                pjIssuelog = data.pjIssuelog,
                pjMemberId = data.pjMemberId,
                pjMemberName = data.pjMemberName,
            };
            db.pjReport.Add(x);
            db.SaveChanges();
        }
        public JsonResult pj篩選出自己的專案(int id,string name)
        {
            //var pjTeamData = from m in db.pjTeam
            //         where m.pjMemberName == name && m.pjProject.pj初審結果 =="通過" && m.pjProject.pj複審結果 == "通過"
            //         || m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager == name
            //                 select new{
            //             pjId = m.pjProject.pjId,
            //             pjName = m.pjProject.pjName,
            //             pjManager = m.pjProject.pjManager,
            //             pjIntroduction = m.pjProject.pjIntroduction,
            //         };           

            var pjTeamData = db.pjTeam.Where(m => m.pjMemberName == name && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" || m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager == name)
                .Select(n => new
                {
                    pjId = n.pjProject.pjId,
                    pjName = n.pjProject.pjName,
                    pjManager = n.pjProject.pjManager,
                    pjIntroduction = n.pjProject.pjIntroduction,
                }).Distinct(); //刪除重複的相同資料
            return Json(pjTeamData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj主管讀取進度回報單(int id)
        {
            var reportData = from m in db.pjReport
                             where m.pjId == id
                             select new
            {
                pjId = m.pjId,
                pjName = m.pjProject.pjName,
                pjMemberId = m.pjMemberId,
                pjMemberName = m.pjMemberName,
                pjReportDate = m.pjReportDate,
                pjReportContent = m.pjReportContent,
                pjIssuelog = m.pjIssuelog,
            };
            return Json(reportData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj主管讀取未分類進度回報單()
        {
            //var reportData = db.pjReport.Select(m => new
            var reportData = from m in db.pjReport
                             orderby m.pjDayReportId descending
                             select new
            {
                pjId = m.pjId,
                pjName = m.pjProject.pjName,
                pjMemberId = m.pjMemberId,
                pjMemberName = m.pjMemberName,
                pjReportDate = m.pjReportDate,
                pjReportContent = m.pjReportContent,
                pjIssuelog = m.pjIssuelog,
            };
            return Json(reportData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj主管搜尋專案列表(string searchVal)
        {
            var data = from m in db.pjProject
                    where m.pj初審結果=="通過"&& m.pj複審結果 == "通過" && m.pjName.Contains(searchVal) || m.pj初審結果 == "通過" && m.pj複審結果 == "通過" && m.pjManager.Contains(searchVal) || m.pj初審結果 == "通過" && m.pj複審結果 == "通過" && m.pjIntroduction.Contains(searchVal)
                       select m;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj成員搜尋專案列表(string searchVal,pjTeam data)
        {
            var pjTeamData = from m in db.pjTeam
                             where m.pjMemberName == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjName.Contains(searchVal)
                             || m.pjMemberName == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager.Contains(searchVal)
                             || m.pjMemberName == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjIntroduction.Contains(searchVal)
                             || m.pjMemberName == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager.Contains(searchVal)

                             || m.pjProject.pjManager == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjName.Contains(searchVal)
                             || m.pjProject.pjManager == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager.Contains(searchVal)
                             || m.pjProject.pjManager == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjIntroduction.Contains(searchVal)
                             || m.pjProject.pjManager == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager.Contains(searchVal)
                             select new
                             {
                                 pjId = m.pjProject.pjId,
                                 pjName = m.pjProject.pjName,
                                 pjManager = m.pjProject.pjManager,
                                 pjIntroduction = m.pjProject.pjIntroduction,
                             };
            return Json(pjTeamData, JsonRequestBehavior.AllowGet);
        }
        public void pj會議記錄表save(pjMeeting data)
        {
            var pjMeetingData = new pjMeeting
            {
                pjId = data.pjId,
                pjMeetingDate = data.pjMeetingDate,
                pjContent = data.pjContent,
                pjMemo = data.pjMemo,
            };
            db.pjMeeting.Add(pjMeetingData);
            db.SaveChanges();
        }
        public JsonResult pjGetAll會議記錄()
        {
            //var pjGetAll會議記錄 = from a in db.pjMeeting
            //                   select a;
            var pjGetAll會議記錄 = db.pjMeeting.Select(m => new {
                pjId = m.pjId,
                pjMeetingDate = m.pjMeetingDate,
                pjContent = m.pjContent,
                pjMemo = m.pjMemo,
                pjName = m.pjProject.pjName,
                pjManager = m.pjProject.pjManager,
                pjMeetingId = m.pjMeetingId,
            });            
            return Json(pjGetAll會議記錄, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj找單筆會議資料(int id)
        {
            var x = db.pjMeeting.FirstOrDefault(m => m.pjMeetingId == id);
            var pjMeeting單筆資料 = new
            {
                pjContent = x.pjContent,
            };
            return Json(pjMeeting單筆資料, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pjFindAll會議記錄ById(int id)
        {
            var data = from d in db.pjMeeting
                       where d.pjId == id
                       select new
                       {
                           pjId = d.pjId,
                           pjMeetingDate = d.pjMeetingDate,
                           pjContent = d.pjContent,
                           pjMemo = d.pjMemo,
                           pjName = d.pjProject.pjName,
                           pjManager = d.pjProject.pjManager,
                       };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj搜尋單筆會議(int id)
        {
            var pj搜尋單筆會議 = from x in db.pjMeeting
                           where x.pjId == id
                           select new
                           {
                               pjId = x.pjId,
                               pjMeetingDate = x.pjMeetingDate,
                               pjMeetingId = x.pjMeetingId,
                               pjContent = x.pjContent,
                               pjMemo = x.pjMemo,
                               pjName = x.pjProject.pjName,
                               pjManager = x.pjProject.pjManager,                               
                           };
            return Json(pj搜尋單筆會議, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj找此專案的會議紀錄(int id)
        {
            var pj找此專案的會議紀錄 = from m in db.pjMeeting
                              where m.pjId == id
                              orderby m.pjMeetingId descending
                              select new
                              {
                                  pjId = m.pjId,
                                  pjMeetingDate = m.pjMeetingDate,
                                  pjMeetingId = m.pjMeetingId,
                                  pjMemo = m.pjMemo,
                                  pjContent = m.pjContent,
                                  pjManager = m.pjProject.pjManager,
                                  pjName = m.pjProject.pjName
                              };
            return Json(pj找此專案的會議紀錄, JsonRequestBehavior.AllowGet);
        }
    }
}