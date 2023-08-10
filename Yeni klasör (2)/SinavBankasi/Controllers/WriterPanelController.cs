using BusniesLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusniesLayer.ValidationRules;
using FluentValidation.Results;

namespace SinavBankasi.Controllers
{
    public class WriterPanelController : Controller
    {
        ExamManager em=new ExamManager(new EfExamDal());
        HedingManager hm = new HedingManager(new EfHedingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterMeneger wm = new WriterMeneger(new EfWritingDal());
        Context c = new Context();
        [Authorize]
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {

           string p = (string)Session["WriterMail"];
           
           id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var writervalue = wm.GetByID(id);
          
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.Writerupdate(p);
                return RedirectToAction("AllHeding","WriterPanel");
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

        public ActionResult MyHeding(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo=c.Writers.Where(x=>x.WriterMail==p).Select(y=>y.WriterID).FirstOrDefault();
            
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeding()
        {
            List<SelectListItem> valuecatagory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecatagory;
            return View(); 
        }
        [HttpPost]
        public ActionResult NewHeding(Heding p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();

            p.HedingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.HedingStatus = true;
            hm.HedingAdd(p);
            return RedirectToAction("MyHeding");
        }
        [HttpGet]
        public ActionResult EditHeding(int id)
        {

            List<SelectListItem> valuecatagory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecatagory;

            var HedingValue = hm.GetByID(id);
            return View(HedingValue);

        }
        [HttpPost]
        public ActionResult EditHeding(Heding p)

        {
            hm.HedingUpdate(p);
            return RedirectToAction("MyHeding");

        }
        public ActionResult DeleteHeding(int id)
        {
            var HedingValue = hm.GetByID(id);
            HedingValue.HedingStatus = false;
            hm.HedingDelete(HedingValue);
            return RedirectToAction("MyHeding");
        }
        public ActionResult AllHeding(int p=1)
        {

            var hedings = hm.GetList().ToPagedList(p, 3);
            return View(hedings); 
        }

        public ActionResult MyExam(string p)
        {

            p =(string)Session["WriterMail"];
            var writeridinfo = c.Exams.Where(x => x.WriterMail == p).Select(y => y. WriterID).FirstOrDefault();

            var values = em.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewExam()
        {
            List<SelectListItem> valuecatagory = (from x in em.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in em.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName+" "+x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();
            ViewBag.vlw = valuewriter;
            ViewBag.vlc = valuecatagory;
            return View();
        }
        [HttpPost]
        public ActionResult NewExam(Exam p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();

            p.ExamDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            
            em.ExamAdd(p);
            return RedirectToAction("MyExam");
        }
        public ActionResult MyContentExam(string p)
        {


            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var examvalue = em.GetListByWriter(writeridinfo);
            return View(examvalue);
        }

    }
}