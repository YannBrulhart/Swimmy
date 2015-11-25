namespace Swimmy.Data.Business
{
    using Swimmy.Entities.Business;

    public class DisciplineConfiguration : EntityBaseConfiguration<Discipline>
    {
        public DisciplineConfiguration()
        {
            this.Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}