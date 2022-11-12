using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class OtherExperiencesController : Controller
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


            var informations = db.TblOtherExperiences.Where(x => x.MemberID == id).ToList();

            return View(informations);



        }
        public ActionResult DeleteOtherExperience(int ID)//entity framework içinde gönderilen parametrenin ismi ID olmak zorundadır.
                                                    //ID gönderilecekse ID olmalıdır. x olamaz.
        {
            var values = db.TblOtherExperiences.Find(ID);//o id ile silinecek elemanı bulur
            db.TblOtherExperiences.Remove(values);//bulduğu değeri siler.
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //önce güncelleyeceğimiz verinin verilerini sayfaya buradan taşırız.

        [HttpGet]
        public ActionResult UpdateOtherExperience(int ID)
        {
            var values = db.TblOtherExperiences.Find(ID);
            return View(values);

        }
        //şimdi güncelleme işlemini yapacak httppost metodunu yazarız.
        [HttpPost]
        public ActionResult UpdateOtherExperience(TblOtherExperiences p)
        {

            //upload image
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını alır. Yüklenen dosyalardan
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Templates/images" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(path));//dosyayı farklı kaydet
                p.ImageUrl = "/Templates/images" + fileName + fileExtension;//veritabanına dosya yol uverilirken
                //~ olmadan yazılır. ~ olursa resim gelmez



            }
            else
            {
                var values2 = db.TblOtherExperiences.Find(p.ExperienceID);
                p.ImageUrl = values2.ImageUrl;
            }
            var mail = Session["MemberMail"].ToString();
            var informations = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = informations.MemberID;
            p.MemberID = id;

            var values = db.TblOtherExperiences.Find(p.ExperienceID);
            //güncelleme
            values.ExperienceTitle = p.ExperienceTitle;
            values.MemberID = p.MemberID;
            values.OrgnizationName = p.OrgnizationName;
            values.Description = p.Description;
            values.Duration = p.Duration;
            values.StartDate = p.StartDate;
            values.EndDate = p.EndDate;
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        public ActionResult ShowDetailPtherExperience(int ID)
        {
            var values = db.TblOtherExperiences.Where(x => x.ExperienceID == ID).ToList();
            return View(values);

        }

        [HttpGet]
        public ActionResult AddOtherExperience()
        {
            //Bu metod sadece sayfa yüklendiği zaman çalışarak boş değer eklemenin önüne geçilecek
            return View();

        }
        [HttpPost]//post işleminde ise bu metodun çalışması sağlanır.
        public ActionResult AddOtherExperience(TblOtherExperiences p)
        {
            //upload image
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını alır. Yüklenen dosyalardan
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Templates/images" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(path));//dosyayı farklı kaydet
                p.ImageUrl= "/Templates/images" + fileName + fileExtension;//veritabanına dosya yol uverilirken
                //~ olmadan yazılır. ~ olursa resim gelmez



            }
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;
            p.MemberID = id;
            db.TblOtherExperiences.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}