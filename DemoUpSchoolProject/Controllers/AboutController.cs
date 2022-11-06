using System;
using System.Collections.Generic;
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
            var values = db.TblAbout.ToList();
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
            var values = db.TblAbout.Find(p.AboutID);//modelden gelen id değerini alır.
            //güncelleme
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