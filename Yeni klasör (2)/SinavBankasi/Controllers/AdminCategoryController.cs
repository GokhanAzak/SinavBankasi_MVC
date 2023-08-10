using BusniesLayer.Concreate;
using BusniesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{
    public class AdminCategoryController : Controller
    {
         CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [Authorize]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        { 
            CategoryValidator categoryvalidatior= new CategoryValidator();
            ValidationResult result= categoryvalidatior.Validate(p); 
            if (result.IsValid) 
            {
                cm.CategoryAdd(p);
                return RedirectToAction ("Index");
            }
            else
            {
                foreach(var item  in result.Errors) 
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue=cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult EditCategory(float id) 
        {
            var categoryvalue=cm.GetByID((int)id);
            return View(categoryvalue);
            
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
           cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}