using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectForDotNet.Models;

namespace ProjectForDotNet.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext appDbContext = new ApplicationDbContext();
        public ViewResult Index()
        {
            var transports = appDbContext.Transports.Include(t => t.Category);
            return View(transports.ToList());
            //return View(appDbContext.Transports);
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(Order order)
        {
            order.DateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                appDbContext.Orders.Add(order);
                appDbContext.SaveChanges();
                return View("OrderComplete");
            }
            return HttpNotFound();

        }
        public ActionResult Gallery() {
            var transports = appDbContext.Transports.Include(t => t.Category);
            return View(transports.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}