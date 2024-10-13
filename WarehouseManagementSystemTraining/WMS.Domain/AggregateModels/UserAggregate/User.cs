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
    }
}
