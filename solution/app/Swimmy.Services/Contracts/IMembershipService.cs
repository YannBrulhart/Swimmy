namespace Swimmy.Services.Contracts
{
    using System.Collections.Generic;

    using Swimmy.Entities.Membership;

    public interface IMembershipService
    {
        MembershipContext ValidateUser(
            string username,
            string password);

        User CreateUser(
            string username,
            string password,
            string email,
            int[] roles);

        User GetUser(
            int userId);

        List<Role> GetUserRoles(
            string username);
    }
}