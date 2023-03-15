using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        EcommerceDbContext db = new EcommerceDbContext();
        public ActionResult Index()
        {
            var data = db.Categorys.Select(s => new CategoryDto() { Id = s.Id, Name = s.Name }).ToList();
            return View(data);
        }
        public ActionResult AddCategory(int? id)
        {
            var model = new CategoryDto();
            if (id.HasValue)
            {
                var edit = db.Categorys.Where(s => s.Id == id).FirstOrDefault();
                model.Id = edit.Id;
                model.Name = edit.Name;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryDto cd)
        {
            if (cd.Id == 0)
            {
                db.Categorys.Add(new Category() { Name = cd.Name });
            }
            else
            {
                var edit = db.Categorys.Where(s => s.Id == cd.Id).FirstOrDefault();
                edit.Name = cd.Name;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var edit = db.Categorys.Where(s => s.Id == id).FirstOrDefault();
            db.Categorys.Remove(edit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}