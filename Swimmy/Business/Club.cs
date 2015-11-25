namespace Swimmy.Entities.Business
{
    using System.Collections.Generic;

    public class Club
    {
        public virtual List<Swimmer> Swimmers { get; set; } = new List<Swimmer>();

        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}