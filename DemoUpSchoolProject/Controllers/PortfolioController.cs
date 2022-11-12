using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class PortfolioController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        // GET: Portfolio
        public ActionResult MyPortfolio()
        {
            return View();
        }
        public ActionResult Portfolio()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            // var id = values.MemberID;
            var id = 1;


            var informations = db.TblLatestWorks.Where(x => x.MemberID == id).ToList();

            return View(informations);
        }
        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Contact(TblContact contact)
        {
            db.TblContact.Add(contact);
            db.SaveChanges();
            return View();
        }

        public PartialViewResult AboutMe()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            //var id = values.MemberID;
            var id = 1;


            var informations = db.TblAbout.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyServices()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            // var id = values.MemberID;
            var id = 1;


            var informations = db.TblServices.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyFeatureSkills()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            //var id = values.MemberID;
            var id = 1;//sadece kendi portfoliom'un görünmesi için


            var informations = db.TblServicesFeature.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyExperiences()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            //var id = values.MemberID;
            var id = 1;


            var informations = db.TblExperiences.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyEducationInformations()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            //var id = values.MemberID;
            var id = 1;


            var informations = db.TblEducationInformations.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyOtherExperiences()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            //var id = values.MemberID;
            var id = 1;


            var informations = db.TblOtherExperiences.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyReferences()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            //var id = values.MemberID;
            var id = 1;


            var informations = db.TblReferences.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult LanguagesInformations()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            //var id = values.MemberID;
            var id = 1;


            var informations = db.TblLanguage.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult HobbiesInformations()
        {
            //var mail = Session["MemberMail"].ToString();
            //var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            //var id = values.MemberID;
            var id = 1;


            var informations = db.TblHobby.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }

        [HttpGet]
        public PartialViewResult ContactPage()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ContactPage(TblContact contact)
        {
            db.TblContact.Add(contact);
            db.SaveChanges();

            return PartialView();
        }
        

    }
}