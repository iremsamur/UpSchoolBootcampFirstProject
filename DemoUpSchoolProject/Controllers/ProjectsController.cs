using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;


            ViewBag.loggedUser = values.MemberName + " " + values.MemberSurname;
            var loggedUserAbout = db.TblAbout.Where(x => x.MemberID == values.MemberID).FirstOrDefault();

            ViewBag.loggedUserImage = loggedUserAbout.ImageUrl;


            var informations = db.TblLatestWorks.Where(x => x.MemberID == id).ToList();

            return View(informations);



        }
        public ActionResult DeleteProject(int ID)//entity framework içinde gönderilen parametrenin ismi ID olmak zorundadır.
                                                 //ID gönderilecekse ID olmalıdır. x olamaz.
        {
            var values = db.TblLatestWorks.Find(ID);//o id ile silinecek elemanı bulur
            db.TblLatestWorks.Remove(values);//bulduğu değeri siler.
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //önce güncelleyeceğimiz verinin verilerini sayfaya buradan taşırız.

        [HttpGet]
        public ActionResult UpdateProject(int ID)
        {
            var values = db.TblLatestWorks.Find(ID);
            return View(values);

        }
        //şimdi güncelleme işlemini yapacak httppost metodunu yazarız.
        [HttpPost]
        public ActionResult UpdateProject(TblLatestWorks p)
        {

            //upload image
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını alır. Yüklenen dosyalardan
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Templates/images" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(path));//dosyayı farklı kaydet
                p.ProjectImage = "/Templates/images" + fileName + fileExtension;//veritabanına dosya yol uverilirken
                //~ olmadan yazılır. ~ olursa resim gelmez



            }
            else
            {
                var values2 = db.TblLatestWorks.Find(p.ProjectID);
                p.ProjectImage = values2.ProjectImage;
            }
            var mail = Session["MemberMail"].ToString();
            var informations = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = informations.MemberID;
            p.MemberID = id;

            var values = db.TblLatestWorks.Find(p.ProjectID);
            //güncelleme
            values.ProjectTitle = p.ProjectTitle;
            values.MemberID = p.MemberID;
            values.ProjectDescription = p.ProjectDescription;
            values.GithubLink = p.GithubLink;
            values.ProjectDate = p.ProjectDate;
            values.ProjectType = p.ProjectType;
            db.SaveChanges();

            return RedirectToAction("Index");


        }


        [HttpGet]
        public ActionResult AddProject()
        {
            //Bu metod sadece sayfa yüklendiği zaman çalışarak boş değer eklemenin önüne geçilecek
            return View();

        }
        [HttpPost]//post işleminde ise bu metodun çalışması sağlanır.
        public ActionResult AddProject(TblLatestWorks p)
        {
            //upload image
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını alır. Yüklenen dosyalardan
                string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Templates/images" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(path));//dosyayı farklı kaydet
                p.ProjectImage = "/Templates/images" + fileName + fileExtension;//veritabanına dosya yol uverilirken
                //~ olmadan yazılır. ~ olursa resim gelmez



            }
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;
            p.MemberID = id;
            db.TblLatestWorks.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}