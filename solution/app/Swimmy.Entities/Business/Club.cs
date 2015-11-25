namespace Swimmy.Entities.Business
{
    using global::System.Collections.Generic;

    using Swimmy.Entities.Contracts;

    public class Club : IEntityBase
    {
        public virtual List<Swimmer> Swimmers { get; set; } = new List<Swimmer>();

        public string Name { get; set; }

        public int Id { get; set; }
    }
}