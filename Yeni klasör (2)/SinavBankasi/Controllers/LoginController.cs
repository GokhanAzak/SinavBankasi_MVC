using BusniesLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SinavBankasi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EfWritingDal());
        StudentsLoginManager sm= new StudentsLoginManager(new EfStudentsDal());
    [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c=new Context();
            var adminuserinfo=c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminuserinfo != null) 
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"]=adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult WriterLogin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writeruserinfo= wm.GetWriter(p.WriterMail,p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("AllHeding", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            
        }
        [HttpGet]
        public ActionResult StudentsLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentsLogin(Students p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var studentuserinfo = sm.GetStudent(p.StudentMail, p.StudentPassword);
            if (studentuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(studentuserinfo.StudentMail, false);
                Session["StudentMail"] = studentuserinfo.StudentMail;
                return RedirectToAction("AllHeding", "StudentsPanel");
            }
            else
            {
                return RedirectToAction("StudentsLogin");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Hedings", "Default");

        }
    }
}