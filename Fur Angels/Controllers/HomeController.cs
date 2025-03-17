using FurAngels.Data;
using FurAngels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BCrypt.Net; // Correct namespace

namespace FurAngels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FurAngelsDbContext _context;

        public HomeController(ILogger<HomeController> logger, FurAngelsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GroomingPage()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult PetShop()
        {
            return View();
        }

        public IActionResult Consult()
        {
            return View();
        }

        public IActionResult Consultform()
        {
            return View();
        }

        public IActionResult Vetconsultform()
        {
            return View();
        }

        public IActionResult PetAbuse()
        {
            return View();
        }

        public IActionResult Training()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == username || u.FullName == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ViewBag.ErrorMessage = "Invalid login attempt.";
                return View();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user, string confirmPassword)
        {
            if (user.PasswordHash != confirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match.";
                return View(user);
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}