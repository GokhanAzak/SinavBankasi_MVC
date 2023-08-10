using BusniesLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{
    public class ExamController : Controller
    {
        ExamManager em=new ExamManager(new EfExamDal());
        WriterMeneger wm = new WriterMeneger(new EfWritingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var exzamvalue = em.GetList();
            return View(exzamvalue);
        }
        [HttpGet]
        public ActionResult ExamAdd()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            List<SelectListItem> valuedescription = (from x in em.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Description,
                                                      Value = x.Description
                                                  }).ToList();
            ViewBag.vlw = valuewriter;
            ViewBag.vld = valuedescription;
            ViewBag.vlc = valuecategory;
            return View();
            
        }
        [HttpPost]
        public ActionResult ExamAdd(Exam exam)
        {
            exam.ExamDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            em.ExamAdd(exam);
            return RedirectToAction("Index");
        }
      

    }
}