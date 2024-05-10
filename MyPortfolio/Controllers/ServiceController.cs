﻿using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        MyPortfolioProjectEntities1 db = new MyPortfolioProjectEntities1();
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }

        public ActionResult MakeActive(int id)
        {
            var values = db.TblServices.Find(id);
            values.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //public ActionResult ChangeStatus(int id)
        //{
        //    var value = db.TblServices.Find(id);
          //  if (value.Status == true)
          //  {
         //       value.Status = false;
       //     }
        // else
       //    {
        //       value.Status = true;
         //   }
       //     db.SaveChanges();
         //   return RedirectToAction("Index");
        //}
        public ActionResult MakePassive(int id)
        {
            var values = db.TblServices.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}