using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Web Application Architecture Project 3 Assignment";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Questions or Comments?";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
