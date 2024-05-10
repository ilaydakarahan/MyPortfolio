using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{   
    [AllowAnonymous] //Herkes erişebilir demek
    public class LoginController : Controller
    {       
        MyPortfolioProjectEntities1 db=new MyPortfolioProjectEntities1(); 

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            var value=db.TblAdmin.FirstOrDefault(x=>x.UserName==admin.UserName &&
            x.Password==admin.Password);

            if(value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false); //çerez oluşturma bu şekilde
                Session["userName"] = value.UserName;   //giriş yaptıktan sonra o süre boyunca bu değeri hafızada tutuyor
                return RedirectToAction("Index" , "About");
            }
            else
            {   //Modelstate error kısmı hata atma
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre yanlış"); //yanlış girilince hata atıyor
                return View();
            }
        }

        public ActionResult Logout()  //Çıkış işlemi için
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Default");
        }
    }
}