﻿using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class HobbyController : Controller
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


            var informations = db.TblHobby.Where(x => x.MemberID == id).ToList();

            return View(informations);



        }
        public ActionResult DeleteHobby(int ID)//entity framework içinde gönderilen parametrenin ismi ID olmak zorundadır.
                                                    //ID gönderilecekse ID olmalıdır. x olamaz.
        {
            var values = db.TblHobby.Find(ID);//o id ile silinecek elemanı bulur
            db.TblHobby.Remove(values);//bulduğu değeri siler.
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //önce güncelleyeceğimiz verinin verilerini sayfaya buradan taşırız.

        [HttpGet]
        public ActionResult UpdateHobby(int ID)
        {
            var values = db.TblHobby.Find(ID);
            return View(values);

        }
        //şimdi güncelleme işlemini yapacak httppost metodunu yazarız.
        [HttpPost]
        public ActionResult UpdateHobby(TblHobby p)
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
                var values2 = db.TblHobby.Find(p.HobbyID);
                p.ImageUrl = values2.ImageUrl;
            }
            var mail = Session["MemberMail"].ToString();
            var informations = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = informations.MemberID;
            p.MemberID = id;

            var values = db.TblHobby.Find(p.HobbyID);
            //güncelleme
            values.HobbyName = p.HobbyName;
            values.MemberID = p.MemberID;
          
            db.SaveChanges();

            return RedirectToAction("Index");


        }
      

        [HttpGet]
        public ActionResult AddHobby()
        {
            //Bu metod sadece sayfa yüklendiği zaman çalışarak boş değer eklemenin önüne geçilecek
            return View();

        }
        [HttpPost]//post işleminde ise bu metodun çalışması sağlanır.
        public ActionResult AddHobby(TblHobby p)
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
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;
            p.MemberID = id;
            db.TblHobby.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}