namespace Swimmy.Data.Business
{
    using Swimmy.Entities.Business;

    public class ResultConfiguration : EntityBaseConfiguration<Result>
    {
        public ResultConfiguration()
        {
            this.Property(g => g.DisciplineId).IsRequired();
            this.Property(g => g.MeetingId).IsOptional();
            this.Property(g => g.SwimmerId).IsRequired();
        }
    }
}