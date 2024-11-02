namespace WMS.Domain.AggregateModels.UserAggregate
{
    public class User
    {
        public Guid UserUUID { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }

        public UserAccount UserAccounts { get; set; }

#pragma warning disable CS8618
        private User() { }

        public User(Guid userUUID, string name, string email, string phone, string address, string position)
        {
            UserUUID = userUUID;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Position = position;
        }

#pragma warning restore CS8618

    }
}
