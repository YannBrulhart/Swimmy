namespace Swimmy.Entities.Business
{
    using System;

    using Swimmy.Entities.Contracts;

    public class Result : IEntityBase
    {
        public Swimmer Swimmer { get; set; }

        public Discipline Discipline { get; set; }

        public TimeSpan EntryTime { get; set; }

        public TimeSpan ResultTime { get; set; }

        public Meeting Meeting { get; set; }

        public int Id { get; set; }
    }
}