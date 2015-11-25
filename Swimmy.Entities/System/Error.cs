namespace Swimmy.Entities.System
{
    using global::System;

    using Swimmy.Entities.Contracts;

    public class Error : IEntityBase
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime DateCreated { get; set; }

        public int Id { get; set; }
    }
}