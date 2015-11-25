namespace Swimmy.Data.Business
{
    using Swimmy.Entities.Business;

    public class ClubConfiguration : EntityBaseConfiguration<Club>
    {
        public ClubConfiguration()
        {
            this.Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}