using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class AboutController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        // GET: About
        

        public ActionResult Index()
        {
            var mail = Session["MemberMail"].ToString();
            var loggedUserInformations = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = loggedUserInformations.MemberID;
           
            ViewBag.loggedUser = loggedUserInformations.MemberName + " " + loggedUserInformations.MemberSurname;

            var loggedUserAbout = db.TblAbout.Where(x => x.MemberID == loggedUserInformations.MemberID).FirstOrDefault();

            ViewBag.loggedUserImage = loggedUserAbout.ImageUrl;

           
            ViewBag.experienceCount = db.TblExperiences.Where(x => x.MemberID == id).Count();//deneyim sayısı
            ViewBag.skillCount = db.TblServices.Where(x => x.MemberID == id).Count();//yetenek sayısı
            ViewBag.projectCount = db.TblLatestWorks.Where(x => x.MemberID == id).Count();//Proje sayısı


            var values = db.TblAbout.Where(x=>x.MemberID==id).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddAbout(TblAbout p)
        {
            db.TblAbout.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        
        public ActionResult DeleteAbout(int ID)
        {
            var values = db.TblAbout.Find(ID);
            db.TblAbout.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");//bu ise bulunduğu kontrol içinde bu metodu Index'i arar.
            //return RedirectToAction("Index","About");//About Controller içindeki Index' git demektir.
            //yönlendirmek istediğimiz url'ı buraya veririz.

        }
        [HttpGet]
        public ActionResult UpdateAbout(int ID)
        {
            var values = db.TblAbout.Find(ID);
            return View(values);

        }
        //şimdi güncelleme işlemini yapacak httppost metodunu yazarız.
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
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
                var values2 = db.TblAbout.Find(p.AboutID);
                p.ImageUrl= values2.ImageUrl;
            }
            var values = db.TblAbout.Find(p.AboutID);//modelden gelen id değerini alır.
            //güncelleme
            var mail = Session["MemberMail"].ToString();
            var informations = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = informations.MemberID;
            p.MemberID = id;

            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            values.NameSurname = p.NameSurname;
            values.Title = p.Title;
            db.SaveChanges();

            return RedirectToAction("Index");
            //eğer html beginform kullanılırsa httpget ve httppost metodu aynı isimli overload olmasa bile çalışırdı.
            //Ama html begin form kullanılırsa bu overload durumu kaldırılabilir.

        }


    }
}