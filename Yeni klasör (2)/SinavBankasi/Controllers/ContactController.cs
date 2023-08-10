using BusniesLayer.Concreate;
using BusniesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{
    public class ContactController : Controller
    {
         ContactManager cm = new ContactManager(new EfContactDal());
         ContactValidator contactValidator = new ContactValidator();
        [Authorize]

        public ActionResult Index()
        {
           var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            EntityLayer.Concreate.Contact contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}