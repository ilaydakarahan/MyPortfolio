using MyPortfolio.Models;
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

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblServices services)
        {
            db.TblServices.Add(services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteService(int id)
        {
            var services = db.TblServices.Find(id);
            db.TblServices.Remove(services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var services=db.TblServices.Find(id);
            return View(services);
        }

        [HttpPost]
        public ActionResult UpdateService(TblServices services)
        {
            var value = db.TblServices.Find(services.ServiceId);
            value.Icon = services.Icon;
            value.Title = services.Title;
            value.Description= services.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}