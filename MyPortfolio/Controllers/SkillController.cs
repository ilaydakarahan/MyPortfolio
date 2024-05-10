using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioProjectEntities1 db=new MyPortfolioProjectEntities1();
        public ActionResult Index()
        {
            var values=db.TblSkills.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkills skills)
        {
            db.TblSkills.Add(skills);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkills.Find(id);
            db.TblSkills.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value=db.TblSkills.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkills skills)
        {
            var value = db.TblSkills.Find(skills.SkillId);
            value.SkillName = skills.SkillName;
            value.Value=skills.Value;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}