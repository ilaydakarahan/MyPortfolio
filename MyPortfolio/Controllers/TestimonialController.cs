using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioProjectEntities1 db=new MyPortfolioProjectEntities1();
        public ActionResult Index()
        {
            var values=db.TblTestimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonials testimonials)
        {
            db.TblTestimonials.Add(testimonials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials testimonials)
        {
            var values = db.TblTestimonials.Find(testimonials.TestimonialId);
            values.ImageUrl = testimonials.ImageUrl;
            values.Comment = testimonials.Comment;
            values.NameSurname=testimonials.NameSurname;
            values.Title=testimonials.Title;
            values.Status=testimonials.Status;
            values.CommendDate=testimonials.CommendDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult ChangeStatus(int id)
        //{
        //    var value = db.TblTestimonials.Find(id);
        //    if (value.Status == true)
        //    {
        //        value.Status = false;
        //    }
        //    else
        //    {
        //        value.Status = true;
        //    }
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        
    }
}