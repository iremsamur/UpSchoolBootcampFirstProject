using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class ReferenceController : Controller
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


            var informations = db.TblReferences.Where(x => x.MemberID == id).ToList();

            return View(informations);



        }
        public ActionResult DeleteReferences(int ID)//entity framework içinde gönderilen parametrenin ismi ID olmak zorundadır.
                                                    //ID gönderilecekse ID olmalıdır. x olamaz.
        {
            var values = db.TblReferences.Find(ID);//o id ile silinecek elemanı bulur
            db.TblReferences.Remove(values);//bulduğu değeri siler.
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //önce güncelleyeceğimiz verinin verilerini sayfaya buradan taşırız.

        [HttpGet]
        public ActionResult UpdateReferences(int ID)
        {
            var values = db.TblReferences.Find(ID);
            return View(values);

        }
        //şimdi güncelleme işlemini yapacak httppost metodunu yazarız.
        [HttpPost]
        public ActionResult UpdateReferences(TblReferences p)
        {

            //upload image
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını alır. Yüklenen dosyalardan
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Templates/images" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(path));//dosyayı farklı kaydet
                p.Image = "/Templates/images" + fileName + fileExtension;//veritabanına dosya yol uverilirken
                //~ olmadan yazılır. ~ olursa resim gelmez



            }
            else
            {
                var values2 = db.TblReferences.Find(p.ReferenceID);
                p.Image = values2.Image;
            }
            var mail = Session["MemberMail"].ToString();
            var informations = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = informations.MemberID;
            p.MemberID = id;

            var values = db.TblReferences.Find(p.ReferenceID);
            //güncelleme
            values.JobTitle = p.JobTitle;
            values.MemberID = p.MemberID;
            values.Comment = p.Comment;
            values.PhoneNumber = p.PhoneNumber;
            values.EMail = p.EMail;
            values.Name = p.Name;
            values.Surname = p.Surname;
            
            values.CompanyName = p.CompanyName;
        
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        

        [HttpGet]
        public ActionResult AddReferences()
        {
            //Bu metod sadece sayfa yüklendiği zaman çalışarak boş değer eklemenin önüne geçilecek
            return View();

        }
        [HttpPost]//post işleminde ise bu metodun çalışması sağlanır.
        public ActionResult AddReferences(TblReferences p)
        {
            //upload image
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını alır. Yüklenen dosyalardan
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Templates/images" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(path));//dosyayı farklı kaydet
                p.Image = "/Templates/images" + fileName + fileExtension;//veritabanına dosya yol uverilirken
                //~ olmadan yazılır. ~ olursa resim gelmez



            }
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;
            p.MemberID = id;
            db.TblReferences.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}