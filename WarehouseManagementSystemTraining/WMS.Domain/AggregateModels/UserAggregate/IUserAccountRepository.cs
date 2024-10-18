namespace WMS.Domain.AggregateModels.UserAggregate
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        bool CheckUser(UserAccountList model);
        User CreateNewUser(UserAccountList model);
        UserAccount CreateNewAccount(UserAccountList model, User newUser);
        Task AddUser(User newUser);
        Task AddUserAccount(UserAccount userAccount);
        UserAccount GetUserAccount(string username);
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash);
    }
}
