namespace Swimmy.Entities.Membership
{
    using Swimmy.Entities.Contracts;

    public class UserRole : IEntityBase
    {
        public int RoleId { get; set; }

        public int UserId { get; set; }

        public virtual Role Role { get; set; }

        public int Id { get; set; }
    }
}