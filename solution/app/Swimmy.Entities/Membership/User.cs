namespace Swimmy.Entities.Membership
{
    using global::System;
    using global::System.Collections.Generic;

    using Swimmy.Entities.Contracts;

    public class User : IEntityBase
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLocked { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual List<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public int Id { get; set; }
    }
}