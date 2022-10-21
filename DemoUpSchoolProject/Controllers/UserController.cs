using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //kolay yönetebilmek için sayfayı parçalara ayıralım
        public PartialViewResult Partial1()
        {
            //View'leri küçük parçalara ayırmak için kullanılan yapı
            return PartialView();
        }
        public PartialViewResult HeadPartial()
        {
            //partial view içinde de tüm veritabanı işlemlerini gerçekleştirebiliriz
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            
            return PartialView();
        }
    }
}