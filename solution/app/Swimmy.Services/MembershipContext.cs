namespace Swimmy.Services
{
    using System.Security.Principal;

    using Swimmy.Entities.Membership;

    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }

        public User User { get; set; }

        public bool IsValid()
        {
            return this.Principal != null;
        }
    }
}