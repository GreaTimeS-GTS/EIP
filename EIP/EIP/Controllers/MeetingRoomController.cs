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
            var booking = db.MeetingRoomBooking.ToList();
            return View(booking);
        }
        //public JsonResult MeetingRoomBooking(MeetingRoomBooking book)
        //{
        //    MeetingRoomBooking Reservation = new MeetingRoomBooking()
        //    {
        //        BookingDate = book.BookingDate,
        //        EmployeeID = book.EmployeeID.
        //        //中文姓名 = book.中文姓名,
        //        //BookingStartTime = book.BookingStartTime,
        //        BookingEndTime = book.BookingEndTime,
        //        MeetingRoomId = book.MeetingRoomId,
        //        //MeetingAttendee = book.MeetingAttendee,
        //        MeetingRemark = book.MeetingRemark,
        //        MeetingRoomName = book.MeetingRoomName,
        //        MeetingSubject = book.MeetingSubject,

        //    };

        //    db.MeetingRoomBooking.Add(Reservation);
        //    db.SaveChanges();
        //    return Json(Reservation, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult MeetingRoomBookingEdit()
        //{
        //    return Json(, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public ActionResult MeetingRoomBooking(MeetingRoomBooking book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.MeetingRoomBooking.Add(book);
        //        db.SaveChanges();
        //        return RedirectToAction("MeetingRoomBookingSearch");
        //    }
        //    return View(book);
        //}
        //public JsonResult MeetingRoomBooking(MeetingRoomBooking book)
        //{
        //    MeetingRoomBooking Reservation = new MeetingRoomBooking()
        //    {
        //        EmployeeID = EmployeeID.book,

        //    }

        //}

        //GET:Delete
        //public ActionResult MeetingRoomDelete(int id)
        //{
        //    var book = db.MeetingRoomBooking.Where(model => model.BookingId == id).FirstOrDefault();
        //    db.MeetingRoomBooking.Remove(book);
        //    db.SaveChanges();
        //    return RedirectToAction("MeetingRoomBookingSearch");
        //}
    }
}