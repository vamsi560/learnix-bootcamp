using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureBootCamp.Context;
using AutoMapper;
using AzureBootCamp.Models;

namespace AzureBootCamp.Controllers
{
    public class UsersController : Controller
    {
        private readonly AZBootcamp2021DBContext _context;
        private readonly IMapper mapper;

        public UsersController(AZBootcamp2021DBContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email,Password")] LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == loginUser.Email);
                if (user != null)
                {
                    if (user.Password == loginUser.Password)
                    {
                        TempData["Name"] = user.Name;
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["errorCode"] = "login";
                    TempData["Error"] = "Invalid Password. You can reset your password through forgot password page";
                    return View("Error", new ErrorViewModel());
                }
                TempData["errorCode"] = "register";
                TempData["Error"] = "User not registered, please register";
                return View("Error", new ErrorViewModel());
            }
            return View(loginUser);
        }

        // GET: Users/Reset
        public IActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reset([Bind("Email,Password,ConfirmPassword")] ForgotPassword forgotPassword)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == forgotPassword.Email);
                if (user != null)
                {
                    user.Password = forgotPassword.Password;
                    _context.SaveChanges();
                    ViewBag.Message = "Password reset Successful";
                    return View();
                }
                TempData["errorCode"] = "register";
                TempData["Error"] = "User not registered, please register";
                return View("Error", new ErrorViewModel());
            }
            return View(forgotPassword);
        }

        // GET: Users/Register
        public IActionResult Register()
        {
            ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserId,Name,Email,Password,ConfirmPassword,Country,CompanyName,Designation,Tracks,Experience")] RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = _context.Users.FirstOrDefault(u => u.Email == registerUser.Email);
                    if (existingUser != null)
                    {
                        TempData["errorCode"] = "registration";
                        TempData["Error"] = "User already exist, reset password / login";
                        return View("Error", new ErrorViewModel());
                    }
                    var user = mapper.Map<User>(registerUser);
                    user.Tracks = string.Join(",", registerUser.Tracks);
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    ViewBag.Message = "Registration Successful";
                    return View();
                }
                catch (Exception)
                {
                    return View("Error", new ErrorViewModel());
                }
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackName", registerUser.Tracks);
            return View(registerUser);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
