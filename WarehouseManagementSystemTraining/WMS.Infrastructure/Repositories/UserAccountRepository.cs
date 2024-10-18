namespace WMS.Infrastructure.Repositories
{
    public class UserAccountRepository : BaseRepository, IUserAccountRepository
    {
        public UserAccountRepository(ApplicationDbContext context) : base(context) { } 

        public bool CheckUser(UserAccountList model)
        {
            return _context.userAccounts.Any(u =>
            u.Account == model.Account);
        }

        public User CreateNewUser(UserAccountList model)
        {
            User newUser = new User
            {
                UserUUID = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                Position = model.Position
            };

            return newUser;
        }

        public UserAccount CreateNewAccount(UserAccountList model, User newUser)
        {
            UserAccount userAccount = new UserAccount
            {

                Account = model.Account,
                Password = model.Password,
                UserUUID = newUser.UserUUID // Liên kết với User
            }; 

            return userAccount;
        }

        public async Task AddUser(User newUser)
        {
            await _context.users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task AddUserAccount(UserAccount userAccount)
        {
            await _context.userAccounts.AddAsync(userAccount);
            await _context.SaveChangesAsync();
        }

        public UserAccount GetUserAccount(string username)
        {
            var userAccount = _context.userAccounts
                .FirstOrDefault(u => u.Account == username);

            return userAccount;
        }

        // Hash mật khẩu bằng SHA256
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Kiểm tra mật khẩu
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHash;
        }
    }
}
