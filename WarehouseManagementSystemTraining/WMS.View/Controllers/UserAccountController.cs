using System.Text;
using System;
using WMS.Domain.AggregateModels.UserAggregate;

namespace WMS.View.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserAccountController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
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
            // Xóa các thông tin không cần thiết trong ModelState
            ModelState.Remove("UserAccountId");
            ModelState.Remove("UserUUID");
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên người dùng đã tồn tại chưa
                if (await _context.userAccounts.AnyAsync(u => u.Account == model.Account))
                {
                    ModelState.AddModelError("", "Tên người dùng đã tồn tại.");
                    return View("Register", model); // Trả về view đăng ký với model hiện tại
                }

                // Hash mật khẩu trước khi lưu
                model.Password = HashPassword(model.Password);

                // Tạo một người dùng mới
                User newUser = new User
                {
                    UserUUID = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    Position = model.Position
                };

                // Thêm người dùng vào bảng users
                await _context.users.AddAsync(newUser);
                await _context.SaveChangesAsync(); // Lưu thay đổi để tạo ID cho User

                // Tạo tài khoản người dùng
                UserAccount userAccount = new UserAccount
                {
                    Account = model.Account,
                    Password = model.Password,
                    UserUUID = newUser.UserUUID // Liên kết với User
                };

                // Thêm tài khoản người dùng vào bảng userAccounts
                await _context.userAccounts.AddAsync(userAccount);
                await _unitOfWork.SaveChangesAsync();

                TempData["SuccessMessage"] = "Đăng ký thành công!";
                return RedirectToAction("Login");
            }

            // Nếu ModelState không hợp lệ, quay về view Register
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
            var userAccount = await _context.userAccounts
                .FirstOrDefaultAsync(u => u.Account == username);

            if (userAccount != null && VerifyPassword(password, userAccount.Password))
            {
                TempData["SuccessMessage"] = "Đăng nhập thành công!";
                return RedirectToAction("Home", "Home");
            }

            // Nếu đăng nhập không thành công
            TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng."; // Lưu thông báo lỗi vào TempData
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View(); // Quay về view hiện tại
        }



        // Hash mật khẩu bằng SHA256
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Kiểm tra mật khẩu
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHash;
        }
    }
}
