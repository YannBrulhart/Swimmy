namespace Swimmy.Data.System
{
    using Swimmy.Entities.Membership;

    public class UserRoleConfiguration : EntityBaseConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            this.Property(ur => ur.UserId).IsRequired();
            this.Property(ur => ur.RoleId).IsRequired();
        }
    }
}