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
using System.Web.UI.WebControls;

namespace SinavBankasi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm=new CategoryManager(new EfCategoryDal());
       

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
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
        public ActionResult AddCategory(Category p, CategoryValidator categoryValidation)
        {
            //cm.CategoryAddBl(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results=categoryValidator.Validate(p);
            if (results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            else
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryist");

            }

            return View();



        }

        
    }
}