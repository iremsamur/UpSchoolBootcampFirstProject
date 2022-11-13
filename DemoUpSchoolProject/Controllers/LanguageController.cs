using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class LanguageController : Controller
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


            var informations = db.TblLanguage.Where(x => x.MemberID == id).ToList();

            return View(informations);



        }
        public ActionResult DeleteLanguage(int ID)//entity framework içinde gönderilen parametrenin ismi ID olmak zorundadır.
                                                              //ID gönderilecekse ID olmalıdır. x olamaz.
        {
            var values = db.TblLanguage.Find(ID);//o id ile silinecek elemanı bulur
            db.TblLanguage.Remove(values);//bulduğu değeri siler.
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //önce güncelleyeceğimiz verinin verilerini sayfaya buradan taşırız.

        [HttpGet]
        public ActionResult UpdateLanguage(int ID)
        {
            var values = db.TblLanguage.Find(ID);
            return View(values);

        }
        //şimdi güncelleme işlemini yapacak httppost metodunu yazarız.
        [HttpPost]
        public ActionResult UpdateLanguage(TblLanguage p)
        {

            var mail = Session["MemberMail"].ToString();
            var informations = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = informations.MemberID;
            p.MemberID = id;

            var values = db.TblLanguage.Find(p.LanguageID);
            //güncelleme
            values.LanguageName = p.LanguageName;
            values.MemberID = p.MemberID;
            values.LanguageLevel = p.LanguageLevel;
     

            db.SaveChanges();

            return RedirectToAction("Index");


        }
 

        [HttpGet]
        public ActionResult AddLanguage()
        {
            //Bu metod sadece sayfa yüklendiği zaman çalışarak boş değer eklemenin önüne geçilecek
            return View();

        }
        [HttpPost]//post işleminde ise bu metodun çalışması sağlanır.
        public ActionResult AddLanguage(TblLanguage p)
        {
            //upload image
          
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;
            p.MemberID = id;
            db.TblLanguage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}