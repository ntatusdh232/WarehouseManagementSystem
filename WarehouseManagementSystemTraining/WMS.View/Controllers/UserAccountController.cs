namespace WMS.View.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserAccountRepository _userAccountRepository;

        // Sửa đổi ở đây
        public UserAccountController(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View("Register");
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterService(UserAccountList model)
        {
            ModelState.Remove("UserAccountId");
            ModelState.Remove("UserUUID");
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                if (_userAccountRepository.CheckUser(model))
                {
                    TempData["ErrorMessage"] = "Tên người dùng đã tồn tại.";
                    ModelState.AddModelError("", "Tên người dùng đã tồn tại.");
                    return View("Register", model);
                }

                model.Password = _userAccountRepository.HashPassword(model.Password);
                User newUser = _userAccountRepository.CreateNewUser(model);
                await _userAccountRepository.AddUser(newUser);

                UserAccount userAccount = _userAccountRepository.CreateNewAccount(model, newUser);
                await _userAccountRepository.AddUserAccount(userAccount);


                TempData["SuccessMessage"] = "Đăng ký thành công!";
                return RedirectToAction("Login");
            }

            return View("Register", model);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View("Login");
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginService(string username, string password)
        {
            var userAccount = _userAccountRepository.GetUserAccount(username);

            if (userAccount != null && _userAccountRepository.VerifyPassword(password, userAccount.Password))
            {
                TempData["SuccessMessage"] = "Đăng nhập thành công!";
                return RedirectToAction("Home", "Home");
            }

            TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View("Login");
        }
    }
}
