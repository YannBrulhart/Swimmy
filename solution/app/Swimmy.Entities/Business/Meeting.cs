namespace Swimmy.Entities.Business
{
    using global::System;
    using global::System.Collections.Generic;

    using Swimmy.Entities.Contracts;

    public class Meeting : IEntityBase
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public virtual List<Result> Results { get; set; } = new List<Result>();

        public int Id { get; set; }
    }
}