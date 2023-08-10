using BusniesLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm=new ContentManager(new EfContentDal());
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GettAllContent(string p) 
        {
           
            var values= cm.GetList(p);
            if (!string.IsNullOrEmpty(p))
            {
                return Json(values);    
              }

            return View(values);
        }


        public ActionResult ContentByHedingID(int id)
        {
            var contentvalues=cm.GetListByHedingID(id);
            return View(contentvalues); 
        }
       
     
        
    }
}