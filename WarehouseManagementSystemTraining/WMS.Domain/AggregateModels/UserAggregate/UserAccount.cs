namespace WMS.Domain.AggregateModels.UserAggregate
{
    public class UserAccount : IAggregateRoot
    {
        public int UserAccountId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public Guid UserUUID { get; set; }
        public User User { get; set; }

#pragma warning disable CS8618
        private UserAccount() { }

        public UserAccount(string account, string password, Guid userUUID)
        {
            Account = account;
            Password = password;
            UserUUID = userUUID;
        }

#pragma warning restore CS8618

    }

    public class UserAccountList
    {
        public int UserAccountId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }

#pragma warning disable CS8618
        private UserAccountList() { }

        public UserAccountList(int userAccountId, string account, string password, string name, string email, 
                               string phone, string address, string position)
        {
            UserAccountId = userAccountId;
            Account = account;
            Password = password;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Position = position;
        }

#pragma warning restore CS8618


    }
}
