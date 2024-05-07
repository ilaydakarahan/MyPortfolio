using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioProjectEntities db=new MyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }
    }
}