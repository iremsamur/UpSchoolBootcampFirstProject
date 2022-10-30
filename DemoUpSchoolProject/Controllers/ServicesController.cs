using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services

        /*
         ToList
        Add
        Remove
        Where
        */
        UpSchoolDbPortfolioEntities1 db = new UpSchoolDbPortfolioEntities1();//modelimi tanımlıyorum.

        //listeleme
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();//tablo içindeki tüm verileri bana liste olarak getirir.

            return View(values);//view içinde bu verileri listeletiyorum.

        }
        //servis ekleme
        [HttpGet]
        public ActionResult AddService()
        {
           //Bu metod sadece sayfa yüklendiği zaman çalışarak boş değer eklemenin önüne geçilecek
            return View();

        }
        [HttpPost]//post işleminde ise bu metodun çalışması sağlanır.
        public ActionResult AddService(TblServices p)
        {
            db.TblServices.Add(p);
            db.SaveChanges();//unitofwork design'da bu save changes tüm işlemler yapıldıktan sonra yapılıyor. burada yapılmıyor.
            return RedirectToAction("Index");
            
        }
        public ActionResult DeleteService(int ID)//entity framework içinde gönderilen parametrenin ismi ID olmak zorundadır.
            //ID gönderilecekse ID olmalıdır. x olamaz.
        {
            var values = db.TblServices.Find(ID);//o id ile silinecek elemanı bulur
            db.TblServices.Remove(values);//bulduğu değeri siler.
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //önce güncelleyeceğimiz verinin verilerini sayfaya buradan taşırız.

        [HttpGet]
        public ActionResult UpdateService(int ID)
        {
            var values = db.TblServices.Find(ID);
            return View(values);

        }
        //şimdi güncelleme işlemini yapacak httppost metodunu yazarız.
        [HttpPost]
        public ActionResult UpdateService(TblServices p)
        {
            var values = db.TblServices.Find(p.ServicesID);//modelden gelen id değerini alır.
            //güncelleme
            values.Title = p.Title;
            db.SaveChanges();

            return RedirectToAction("Index");
            //eğer html beginform kullanılırsa httpget ve httppost metodu aynı isimli overload olmasa bile çalışırdı.
            //Ama html begin form kullanılırsa bu overload durumu kaldırılabilir.

        }

    }
}