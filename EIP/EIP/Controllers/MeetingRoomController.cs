using EIP.Models;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class MeetingRoomController : Controller
    {
        // GET: MeetingRoom

        dbEIPEntities db = new dbEIPEntities();
        public ActionResult MeetingRoomBookingSearch()
        {           
            return View();
        }
       
    }
}