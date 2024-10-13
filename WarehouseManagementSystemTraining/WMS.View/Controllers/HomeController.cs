namespace WMS.View.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Login()
        {
            return RedirectToAction("Login", "UserAccount");
            // return View("~/Views/UserAccount/Login.cshtml")
        }

        public IActionResult Register()
        {
            return RedirectToAction("Register", "UserAccount");
            // return View("~/Views/UserAccount/Register.cshtml")
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
