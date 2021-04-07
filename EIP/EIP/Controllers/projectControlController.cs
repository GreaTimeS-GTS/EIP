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


        //總表
        public JsonResult getPjProjectData()
        {
            var data = db.pjProject.Select(m => new
            {
                pjId = m.pjId,
                pjName = m.pjName,
                pj審核階段 = m.pj審核階段,
                pj初審結果 = m.pj初審結果,
                pjMemberCount = m.pjMemberCount,
                pjManager = m.pjManager,
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //總表

        //複審審核
        public JsonResult getPjProjectDatat2()
        {
            var pjm = from m in db.pjProject
                      where  m.pj複審結果 =="不通過" || m.pj複審結果 == "未審核" &&m.pj審核階段 == "複審"

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
                      where m.pj初審結果 == "不通過" || m.pj初審結果 == "未審核" && m.pj審核階段 == "初審"
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




        public JsonResult getPjTeamDataFromId(int id)
        {
            var teamData = from cc in db.pjTeam
                    where cc.pjId == id
                    select cc;
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

        public void getPjProjectDataFromIdto2(int id)
        {
            var d = db.pjProject.FirstOrDefault(m => m.pjId == id);
            {
                d.pj審核階段 = "複審";
                d.pj複審結果 = "未審核";
            }
            db.SaveChanges(); 
        }


        public void savePreview2FormData(pjTeam formdata)
        {
            db.pjTeam.Add(formdata);
            db.SaveChanges();
        }
        public void pj審核結果儲存(pjProject data)
        {
            db.Entry<pjProject>(data).State = EntityState.Modified; //整筆資料全部覆寫
            db.SaveChanges();
        }

        public void pj審核意見(pjAdvice ad)
        {
            var a = new        pjAdvice

            {
             pjId=ad.pjId,
               pj意見內容=ad.pj意見內容,
                pj審核階段 = ad.pj審核階段,
            };


            db.pjAdvice.Add(a);
            db.SaveChanges();
        }

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
    }
}