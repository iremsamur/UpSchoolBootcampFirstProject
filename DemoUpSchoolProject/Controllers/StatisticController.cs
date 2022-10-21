using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class StatisticController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.v1= db.TblTestimonial.Count();//referansların toplam sayısı
            ViewBag.v2 = db.TblTestimonial.Where(x => x.City == "İstanbul").Count();//istanbuldaki referans sayısı
            //yazılım mühendisi haricindeki kişi sayısı
            ViewBag.v3 = db.TblTestimonial.Where(x => x.Profession != "Yazılım Mühendisi").Count();
            //şehri trabzon olanın kişi ismini getiren sorgu
            ViewBag.v4 = db.TblTestimonial.Where(x => x.City == "Trabzon").Select(y => y.NameSurname).FirstOrDefault();//sadece select içinde belirtilen
            //sütunu getirir
            //tek değerin dönmesi gereken durumda FirstorDefault kullanılır.
            //tüm değerler için tolist olur.
            //referansların ortalama maaşı
            ViewBag.v5 = db.TblTestimonial.Average(x => x.Balance);

            return View();
        }
    }
}