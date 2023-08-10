using BusniesLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{
    public class DefaultController : Controller
    {
        HedingManager hm = new HedingManager(new EfHedingDal());
       ContentManager cm = new ContentManager(new EfContentDal());
        [AllowAnonymous]
        public ActionResult Hedings()
        {
            var hedinglist=hm.GetList();
            return View(hedinglist);
        }
        public PartialViewResult Index(int id=0)
        {
            
            var contentlist=cm.GetListByHedingID(id);
            return PartialView(contentlist);
        }
    }
}