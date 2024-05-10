using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
        MyPortfolioProjectEntities1 db=new MyPortfolioProjectEntities1();
        public ActionResult Index()
        {
            var values=db.TblTeams.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTeam()
        {          
            return View();
        }
        [HttpPost]
        public ActionResult AddTeam(TblTeams teams)
        {
            db.TblTeams.Add(teams);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTeam(int id)
        {
            var team=db.TblTeams.Find(id);
            db.TblTeams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var value=db.TblTeams.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTeam(TblTeams teams)
        {
            var value = db.TblTeams.Find(teams.TeamId);
            value.ImageUrl = teams.ImageUrl;
            value.NameSurname=teams.NameSurname;           
            value.Title= teams.Title;
            value.Description= teams.Description;
            value.TwitterUrl=teams.TwitterUrl;
            value.FacebookUrl=teams.FacebookUrl;
            value.LinkedinUrl=teams.LinkedinUrl;
            value.InstagramUrl=teams.InstagramUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}