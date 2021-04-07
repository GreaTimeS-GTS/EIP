using EIP.Models;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        public ActionResult BookingView()
        {

            return View();

        }

        public JsonResult GetBooking()
        {

            var events = db.MeetingRoomBooking.ToList();
            Console.WriteLine(events);
            return Json(events, JsonRequestBehavior.AllowGet);
        }

        public JsonResult checkBoxStatus(string Room)
        {
            var bb = db.MeetingRoomBooking.Where(a => a.MeetingRoomName == Room).Select(editevent => new
            {
                BookingId=editevent.BookingId,
                MeetingRoomName = editevent.MeetingRoomName,
                MeetingRemark = editevent.MeetingRemark,
                BookingStartTime = editevent.BookingStartTime,
                BookingEndTime = editevent.BookingEndTime,
                isAllday = editevent.IsAllDay,
                MeetingSubject = editevent.MeetingSubject,
                EmployeeID = editevent.EmployeeID,
                中文姓名 = editevent.中文姓名,
                MeetingAttentee = editevent.MeetingAttentee,            
            });
            //var getByRoomName = new
            //{
            //    emId=editevent.EmployeeID,
            //    emName=editevent.中文姓名,
            //    MeetingRoomName=editevent.MeetingRoomName,
            //    MeetingSubject=editevent.MeetingSubject,
            //    startTime=editevent.BookingStartTime,
            //    endTime=editevent.BookingEndTime,
            //    attendee=editevent.MeetingAttentee,
            //    Description=editevent.MeetingRemark,
            //    isAllday=editevent.IsAllDay,       
            //};
            return Json(bb, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveEvent(MeetingRoomBooking e)
        {
            var status = false;

            if (e.BookingId > 0)
            {
                var v = db.MeetingRoomBooking.Where(a => a.BookingId == e.BookingId).FirstOrDefault();
                if (v != null)
                {
                    v.EmployeeID = e.EmployeeID;
                    v.中文姓名 = e.中文姓名;
                    v.MeetingRoomName = e.MeetingRoomName;
                    v.MeetingSubject = e.MeetingSubject;
                    v.BookingStartTime = e.BookingStartTime;
                    v.BookingEndTime = e.BookingEndTime;
                    v.MeetingAttentee = e.MeetingAttentee;
                    v.MeetingRemark = e.MeetingRemark;
                    v.IsAllDay = e.IsAllDay;
                }
            }
            else { db.MeetingRoomBooking.Add(e); }
            db.SaveChanges();
            status = true;
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            //MeetingRoomBooking v = db.MeetingRoomBooking.Find(bockingId);
            //db.MeetingRoomBooking.Remove(v);
            //db.SaveChanges();

            //return Json(v, JsonRequestBehavior.AllowGet);

            var status = false;
            var v = db.MeetingRoomBooking.Where(a => a.BookingId == eventID).FirstOrDefault();
            if (v != null)
            {
                db.MeetingRoomBooking.Remove(v);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }       
    }
}