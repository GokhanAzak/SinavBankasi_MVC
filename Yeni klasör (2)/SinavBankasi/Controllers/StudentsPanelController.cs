using BusniesLayer.Concreate;
using BusniesLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{

    public class StudentsPanelController : Controller
    {
        ExamManager em = new ExamManager(new EfExamDal());
        HedingManager hm = new HedingManager(new EfHedingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        StudentsLoginManager sm = new StudentsLoginManager(new EfStudentsDal());
        Context c = new Context();
        [Authorize]
        [HttpGet]
        public ActionResult StudentsProfile(int id=0)
        {
            string p = (string)Session["StudentMail"];

            id = c.Students.Where(x => x.StudentMail == p).Select(y => y.StudentID).FirstOrDefault();

            var studentvalue = sm.GetByID(id);

            return View(studentvalue);
        }
        [HttpPost]
        public ActionResult StudentsProfile(Students p)
        {
            StudentsValidation studentValidator = new StudentsValidation();
            ValidationResult results = studentValidator.Validate(p);
            if (results.IsValid)
            {
                sm.StudentsUpdate(p);
                return RedirectToAction("StudentsProfile", "StudentsPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }

            return View();

        }
        public ActionResult AllHeding(int p = 1)
        {

            var hedings = hm.GetList().ToPagedList(p, 3);
            return View(hedings);
        }
        public ActionResult Exam(string p)
        {

            p = (string)Session["StudentMail"];
            var studentidinfo = c.Students.Where(x => x.StudentMail == p).Select(y => y.StudentID).FirstOrDefault();

            var values = em.GetListByWriter(studentidinfo);
            return View(values);
        }
    }
}