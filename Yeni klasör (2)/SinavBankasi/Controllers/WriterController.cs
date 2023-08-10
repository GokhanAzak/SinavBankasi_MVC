using BusniesLayer.Concreate;
using BusniesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{
    public class WriterController : Controller
    {
        WriterMeneger wm=new WriterMeneger(new EfWritingDal());
         WriterValidator writerValidator = new WriterValidator();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }
        [HttpGet]
        public ActionResult AddWriter() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p) 
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.Writeradd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors) 
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
                return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id) 
        {
            var writervalue=wm.GetByID(id);
            return View(writervalue);

        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.Writerupdate(p);
                return RedirectToAction("Index");
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
        
    }
}