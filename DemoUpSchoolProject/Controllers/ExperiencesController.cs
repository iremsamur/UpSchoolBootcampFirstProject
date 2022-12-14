using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            
            //upload image
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını alır. Yüklenen dosyalardan
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Templates/images" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(path));//dosyayı farklı kaydet
                p.CompanyLogo = "/Templates/images" + fileName + fileExtension;//veritabanına dosya yol uverilirken
                //~ olmadan yazılır. ~ olursa resim gelmez



            }
            else
            {
                var values2 = db.TblExperiences.Find(p.ExperienceID);
                p.CompanyLogo = values2.CompanyLogo;
            }
            var mail = Session["MemberMail"].ToString();
            var informations = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = informations.MemberID;
            p.MemberID = id;

            var values = db.TblExperiences.Find(p.ExperienceID);
            //güncelleme
            values.JobTitle = p.JobTitle;
            values.MemberID = p.MemberID;
            values.CompanyName = p.CompanyName;
            values.Duration = p.Duration;
            values.CompanyLogo = p.CompanyLogo;
            values.Description = p.Description;
            db.SaveChanges();

            return RedirectToAction("Index");
           

        }
        public ActionResult ShowDetailExperience(int ID)
        {
            var values = db.TblExperiences.Where(x=>x.ExperienceID==ID).ToList();
            return View(values);

        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            //Bu metod sadece sayfa yüklendiği zaman çalışarak boş değer eklemenin önüne geçilecek
            return View();

        }
        [HttpPost]//post işleminde ise bu metodun çalışması sağlanır.
        public ActionResult AddExperience(TblExperiences p)
        {
            //upload image
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını alır. Yüklenen dosyalardan
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Templates/images" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(path));//dosyayı farklı kaydet
                p.CompanyLogo = "/Templates/images" + fileName + fileExtension;//veritabanına dosya yol uverilirken
                //~ olmadan yazılır. ~ olursa resim gelmez



            }
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
             var id = values.MemberID;
            p.MemberID = id;
            db.TblExperiences.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}