using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concreate;
using BusniesLayer.Concreate;

namespace SinavBankasi.Controllers
{
    public class AboutController : Controller
    {
         AboutManager abm =new AboutManager(new EfAboutDal());
        [Authorize]
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult AboutAdd(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}