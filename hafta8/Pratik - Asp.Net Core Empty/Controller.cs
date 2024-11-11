using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Log page access
            _logger.LogInformation($"Home page accessed at: {DateTime.UtcNow}");

            // Create sample data for the view
            var viewModel = new HomeViewModel
            {
                WelcomeMessage = "Welcome to Our Platform",
                CurrentTime = DateTime.Now,
                FeaturedItems = new List<string>
                {
                    "Latest News",
                    "Featured Products",
                    "Special Offers"
                }
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult About()
        {
            var model = new AboutViewModel
            {
                Title = "About Us",
                Description = "We are a dynamic team focused on delivering quality solutions.",
                TeamMembers = new List<TeamMember>
                {
                    new TeamMember { Name = "John Doe", Role = "Developer" },
                    new() { Name = "Jane Smith", Role = "Designer" }
                }
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View(new ContactViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (ModelState.IsValid)
            {
                // Log the contact form submission
                _logger.LogInformation($"Contact form submitted by {model.Email}");

                // TODO: Process the contact form
                // Here you would typically send an email or save to database

                TempData["Message"] = "Thank you for your message. We'll respond soon!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(model: new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}