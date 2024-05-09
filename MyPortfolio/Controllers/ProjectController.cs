using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfolioProjectEntities1 db=new MyPortfolioProjectEntities1();

        public ActionResult Index()
        {
            var values=db.TblProjects.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            var categories=db.TblCategories.ToList();

            List<SelectListItem> categoryList= (from x in categories select new SelectListItem
            {
                Text=x.CategoryName,
                Value=x.CategoryId.ToString()
            }).ToList();

            ViewBag.category=categoryList;

            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProjects projects)
        {
            db.TblProjects.Add(projects);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var categories = db.TblCategories.ToList();

            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();

            ViewBag.category = categoryList;

            var value = db.TblProjects.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProjects projects)
        {
            var value = db.TblProjects.Find(projects.ProjectId);
            value.ProjectName= projects.ProjectName;
            value.ImageUrl= projects.ImageUrl;
            value.GithubUrl= projects.GithubUrl;
            value.CategoryId= projects.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value=db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}