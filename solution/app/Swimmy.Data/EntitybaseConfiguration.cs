namespace Swimmy.Data
{
    using global::System.Data.Entity.ModelConfiguration;

    using Swimmy.Entities.Contracts;

    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T>
        where T : class, IEntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.Id);
        }
    }
}