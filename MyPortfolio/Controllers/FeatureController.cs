using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        MyPortfolioProjectEntities1 db=new MyPortfolioProjectEntities1();

        public ActionResult Index()
        {
            var value=db.TblFeatures.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values=db.TblFeatures.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeatures features)
        {
            var values = db.TblFeatures.Find(features.FeatureId);
            values.NameSurname=features.NameSurname; 
            values.Title=features.Title;
            values.ImageUrl=features.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}