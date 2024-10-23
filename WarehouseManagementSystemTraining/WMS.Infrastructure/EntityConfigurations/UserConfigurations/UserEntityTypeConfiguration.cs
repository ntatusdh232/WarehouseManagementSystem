namespace WMS.Infrastructure.EntityConfigurations.UserConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserUUID);

            builder.Property(u => u.UserUUID)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(u => u.Name)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.Property(u => u.Phone)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.Position)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasOne(u => u.UserAccounts)
                   .WithOne(u => u.User)
                   .HasForeignKey<UserAccount>(a => a.UserUUID);
        }
    }
}
