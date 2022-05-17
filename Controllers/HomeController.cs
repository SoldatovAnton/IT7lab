using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT7lab.Models;

namespace IT7lab.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Доброе утро!" : "Добрый день!";   
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guest)
        {
            if (ModelState.IsValid)
            {
                //отправка данных гостя по эл. почте
                WebService1 client = new WebService1();
                client.AddGuest(guest.Name, guest.Email, guest.Phone, guest.WillAttend);
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }

    }
}