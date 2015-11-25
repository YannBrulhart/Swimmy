namespace Swimmy.Entities.Business
{
    using System;
    using System.Collections.Generic;

    using Swimmy.Entities.Contracts;

    public class Swimmer : IEntityBase
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public DateTime Birth { get; set; }

        public virtual Club Club { get; set; }

        public virtual List<Result> Results { get; set; } = new List<Result>();

        public int Id { get; set; }
    }
}