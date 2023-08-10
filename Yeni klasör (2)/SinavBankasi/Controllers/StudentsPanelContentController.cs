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
    public class StudentsPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult MyContents(string p)
        {


            p = (string)Session["StudentMail"];
            var studentidinfo = context.Students.Where(x => x.StudentMail == p).Select(y => y.StudentID).FirstOrDefault();
            var contentvalues = cm.GetList(p);
            return View(contentvalues);
        }
    }
}