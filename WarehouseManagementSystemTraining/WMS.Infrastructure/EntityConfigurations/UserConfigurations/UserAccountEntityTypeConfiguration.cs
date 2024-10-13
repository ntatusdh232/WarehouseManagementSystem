namespace WMS.Infrastructure.EntityConfigurations.UserConfigurations
{
    public class UserAccountEntityTypeConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {

            builder.HasKey(a => a.UserAccountId);

            builder.Property(a => a.UserAccountId)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(a => a.Account)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Password)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasOne(a => a.User)
                   .WithOne(a => a.UserAccounts)
                   .HasForeignKey<UserAccount>(a => a.UserUUID);
        }
    }
}
