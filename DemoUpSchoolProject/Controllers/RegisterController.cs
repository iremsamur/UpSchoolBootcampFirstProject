using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class RegisterController : Controller
    {
        UpSchoolDbPortfolioEntities1 db = new UpSchoolDbPortfolioEntities1();
        // GET: Register

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(TblMember p)
        {
            try
            {
               

                db.TblMember.Add(p);
                db.SaveChanges();
                ViewBag.check = true;
               
                return RedirectToAction("Index", "Login");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return View();
                
            }
           
        }
    }
}