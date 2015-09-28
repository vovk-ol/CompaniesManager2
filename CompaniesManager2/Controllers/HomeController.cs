using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompaniesManager2.Models;
using System.Data.Entity;

namespace CompaniesManager2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.DateTimeNow = DateTime.Now;
            return View();
        }      
        
    }
}