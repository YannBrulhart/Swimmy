namespace Swimmy.Entities.Business
{
    using global::System;

    using Swimmy.Entities.Contracts;

    public class Result : IEntityBase
    {
        public int SwimmerId { get; set; }

        public Swimmer Swimmer { get; set; }

        public int DisciplineId { get; set; }

        public Discipline Discipline { get; set; }

        public TimeSpan EntryTime { get; set; }

        public TimeSpan ResultTime { get; set; }

        public int MeetingId { get; set; }

        public Meeting Meeting { get; set; }

        public int Id { get; set; }
    }
}