namespace Swimmy.Entities.Business
{
    using System.Collections.Generic;

    using Swimmy.Entities.Contracts;

    public class Discipline : IEntityBase
    {
        public string Name { get; set; }

        public virtual List<Result> Results { get; set; } = new List<Result>();

        public int Id { get; set; }
    }
}