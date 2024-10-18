namespace WMS.Domain.AggregateModels.UserAggregate
{
    public class UserAccount : IAggregateRoot
    {
        public int UserAccountId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public Guid UserUUID { get; set; }
        public User User { get; set; }

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

    }
}
