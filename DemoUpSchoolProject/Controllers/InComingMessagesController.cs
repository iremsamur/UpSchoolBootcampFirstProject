using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class InComingMessagesController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;


            ViewBag.loggedUser = values.MemberName + " " + values.MemberSurname;
            var loggedUserAbout = db.TblAbout.Where(x => x.MemberID == values.MemberID).FirstOrDefault();

            ViewBag.loggedUserImage = loggedUserAbout.ImageUrl;


            var informations = db.TblContact.ToList();

            return View(informations);



        }
        public ActionResult DeleteContact(int ID)//entity framework içinde gönderilen parametrenin ismi ID olmak zorundadır.
                                                    //ID gönderilecekse ID olmalıdır. x olamaz.
        {
            var values = db.TblContact.Find(ID);//o id ile silinecek elemanı bulur
            db.TblContact.Remove(values);//bulduğu değeri siler.
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //önce güncelleyeceğimiz verinin verilerini sayfaya buradan taşırız.

     
    }
}