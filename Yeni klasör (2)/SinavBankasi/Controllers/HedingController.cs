using BusniesLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{
    public class HedingController : Controller
    {
        HedingManager hm=new HedingManager(new EfHedingDal());
        CategoryManager cm=new CategoryManager(new EfCategoryDal());
        WriterMeneger wm=new WriterMeneger(new EfWritingDal());
        [Authorize]
        public ActionResult Index()
        {
            var hedingvalues=hm.GetList();
            return View(hedingvalues);
        }
        [HttpGet]
        public ActionResult AddHeding()
        {
            List<SelectListItem> valuecatagory = (from x in cm.GetList() select new SelectListItem
            { Text = x.CategoryName,Value=x.CategoryID.ToString()
            }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName+" "+x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlc=valuecatagory;
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeding(Heding p)
        {
            p.HedingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HedingAdd(p);
            return RedirectToAction("Index");
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

            var HedingValue=hm.GetByID(id);
            return View(HedingValue);

        }
        [HttpPost]
        public ActionResult EditHeding(Heding p)

        {
            hm.HedingUpdate(p);
            return RedirectToAction("Index");

        }
        public ActionResult DeleteHeding(int id)
        {
            var HedingValue=hm.GetByID(id);
            HedingValue.HedingStatus = false;
            hm.HedingDelete(HedingValue);
            return RedirectToAction("Index");
        }
    }
}