using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioProjectEntities1 db=new MyPortfolioProjectEntities1();
        public ActionResult Index()
        {
            var values=db.TblSocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias socialMedias)
        {
            db.TblSocialMedias.Add(socialMedias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var socialmedia= db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(socialmedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values= db.TblSocialMedias.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias socialMedias)
        {
            var values = db.TblSocialMedias.Find(socialMedias.SocialMediaId);
            values.SocialMediaName=socialMedias.SocialMediaName;
            values.Url=socialMedias.Url;
            values.Icon=socialMedias.Icon;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}