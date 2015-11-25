namespace Swimmy.Data.Business
{
    using Swimmy.Entities.Business;

    public class SwimmerConfiguration : EntityBaseConfiguration<Swimmer>
    {
        public SwimmerConfiguration()
        {
            this.Property(g => g.Name).IsRequired().HasMaxLength(50);
            this.Property(g => g.FirstName).IsRequired().HasMaxLength(50);
            this.Property(g => g.ClubId).IsOptional();
            this.HasMany(g => g.Results).WithRequired(r => r.Swimmer).HasForeignKey(r =>r.SwimmerId);
        }
    }
}