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
        UpSchoolDbPortfolioEntities1 db = new UpSchoolDbPortfolioEntities1();
        // GET: Portfolio
        public ActionResult MyPortfolio()
        {
            return View();
        }
        public ActionResult Portfolio()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult AboutMe()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;


            var informations = db.TblAbout.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyServices()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;


            var informations = db.TblServices.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyFeatureSkills()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;


            var informations = db.TblServicesFeature.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyExperiences()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;


            var informations = db.TblExperiences.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }
        public PartialViewResult MyReferences()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            var id = values.MemberID;


            var informations = db.TblReferences.Where(x => x.MemberID == id).ToList();
            return PartialView(informations);
        }

    }
}