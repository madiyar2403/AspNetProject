using ProjectForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectForDotNet.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext appDbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(appDbContext.Transports);
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Buy(Order order)
        {
            order.DateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                appDbContext.Orders.Add(order);
                appDbContext.SaveChanges();
                return $"Dear, {order.FirstName}, you will be contacted soon!";
            }
            return $"You entered wrong order, please create new!";
            
        }
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}