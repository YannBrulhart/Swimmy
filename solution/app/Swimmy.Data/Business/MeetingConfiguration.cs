namespace Swimmy.Data.Business
{
    using Swimmy.Entities.Business;

    public class MeetingConfiguration : EntityBaseConfiguration<Meeting>
    {
        public MeetingConfiguration()
        {
            this.Property(g => g.Name).IsRequired().HasMaxLength(50);
            this.Property(g => g.Date).IsRequired();
        }
    }
}