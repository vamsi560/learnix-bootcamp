using AzureBootCamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AzureBootCamp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBootCamp.Controllers
{
    public class HomeController : Controller
    {
    private readonly ILogger<HomeController> _logger;
    // private readonly AZBootcamp2021DBContext context;

        public HomeController(ILogger<HomeController> logger, AZBootcamp2021DBContext context)
        {
            _logger = logger;
            // this.context = context;
        }

        public IActionResult Index()
        {
            // Restore DB query for tracks
            // ViewBag.Tracks = context.Tracks.ToList(); // DB code commented out
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NavigateRegister()
        {
            return RedirectToAction("Register", "Users");
        }


        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult NavigateTrack()
        {
            return RedirectToAction("Index", "Tracks");
        }

        public IActionResult NavigateLogin()
        {
            return RedirectToAction("Login", "Users");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
