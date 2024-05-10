using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioProjectEntities1 db=new MyPortfolioProjectEntities1();
        public ActionResult Index()
        {
            var value=db.TblMessages.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(TblMessages messages)
        {
            db.TblMessages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMessage(int id)
        {
            var value=db.TblMessages.Find(id);
            db.TblMessages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value= db.TblMessages.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMessage(TblMessages messages)
        {
            var values = db.TblMessages.Find(messages.MessageId);
            values.Name = messages.Name;
            values.Email = messages.Email;
            values.Subject = messages.Subject;
            values.MessageContent = messages.MessageContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}