using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class ExperiencesController : Controller
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


            var informations = db.TblExperiences.Where(x => x.MemberID == id).ToList();

            return View(informations);

          
            
        }
        public ActionResult DeleteExperience(int ID)//entity framework içinde gönderilen parametrenin ismi ID olmak zorundadır.
                                                 //ID gönderilecekse ID olmalıdır. x olamaz.
        {
            var values = db.TblExperiences.Find(ID);//o id ile silinecek elemanı bulur
            db.TblExperiences.Remove(values);//bulduğu değeri siler.
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //önce güncelleyeceğimiz verinin verilerini sayfaya buradan taşırız.

        [HttpGet]
        public ActionResult UpdateExperience(int ID)
        {
            var values = db.TblExperiences.Find(ID);
            return View(values);

        }
        //şimdi güncelleme işlemini yapacak httppost metodunu yazarız.
        [HttpPost]
        public ActionResult UpdateExperience(TblExperiences p)
        {
            var values = db.TblExperiences.Find(p.ExperienceID);
            //güncelleme
            values.JobTitle = p.JobTitle;
            values.MemberID = 1;
            values.CompanyName = p.CompanyName;
            values.Duration = p.Duration;
            values.CompanyLogo = "test";
            values.Description = p.Description;
            db.SaveChanges();

            return RedirectToAction("Index");
           

        }
        public ActionResult ShowDetailExperience(int ID)
        {
            var values = db.TblExperiences.Where(x=>x.ExperienceID==ID).ToList();
            return View(values);

        }

    }
}