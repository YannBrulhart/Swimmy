namespace Swimmy.Entities.Membership
{
    using Swimmy.Entities.Contracts;

    public class Role : IEntityBase
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}