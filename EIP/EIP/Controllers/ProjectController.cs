using EIP.Models;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EIP.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project

        dbEIPEntities dbEIP = new dbEIPEntities();

        ProjectModel Pj = new ProjectModel();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EmpIndex()
        {
            var qPjList = dbEIP.工作清單.Select(m => new ProjectListViewModel()
            {
                事項名稱 = m.事項名稱,
                專案歸類 = m.專案歸類,
                完成度 = m.完成度,
                //專案內容 = m.專案內容,
                完成日 = m.完成日
            });



            return View(qPjList);
        }


        public ActionResult CreateProject()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(工作清單 pj)
        {
            
            dbEIP.工作清單.Add(pj);
            dbEIP.SaveChanges();
            return RedirectToAction("EmpIndex","Project");
        }

    }
}