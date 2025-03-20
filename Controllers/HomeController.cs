using Conference.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Conference.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Pass data to the view using ViewBag
            ViewBag.ConferenceName = "Tech Summit 2025";
            ViewBag.ConferenceDate = "June 15-17, 2025";
            ViewBag.ConferenceLocation = "San Francisco, CA";

            return View();
        }

        // GET: Home/Register
        [HttpGet]
        public ActionResult Register()
        {
            // Create a list of workshop options to display in the form
            ViewBag.Tracks = new List<SelectListItem>
            {
                new SelectListItem { Text = "Web Development", Value = "web" },
                new SelectListItem { Text = "Mobile Development", Value = "mobile" },
                new SelectListItem { Text = "Cloud Computing", Value = "cloud" },
                new SelectListItem { Text = "Data Science", Value = "data" },
                new SelectListItem { Text = "DevOps", Value = "devops" }
            };

            return View();
        }

        // POST : Home/Register
        [HttpPost]
        public ActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                // In a real application, we would save to a database here
                // For this demo, we'll just set an ID and registration date
                registration.ID = new Random().Next(1000, 9999); // Generate a random ID
                registration.RegistrationDate = DateTime.Now;

                ViewBag.Registration = registration;

                return View("Confirmation",registration);
            }

            // Create a list of workshop options to display in the form
            ViewBag.Tracks = new List<SelectListItem>
            {
                new SelectListItem { Text = "Web Development", Value = "web" },
                new SelectListItem { Text = "Mobile Development", Value = "mobile" },
                new SelectListItem { Text = "Cloud Computing", Value = "cloud" },
                new SelectListItem { Text = "Data Science", Value = "data" },
                new SelectListItem { Text = "DevOps", Value = "devops" }
            };

            return View(registration);

        }

        // GET: Home/Confirmation/123
        public ActionResult Confirmation()
        {
            var registration = ViewBag.Registration;
            if (registration == null)
            {
                return RedirectToAction("Index");
            }

            return View(registration);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
