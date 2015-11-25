namespace Swimmy.Data.Extensions
{
    using global::System.Linq;

    using Swimmy.Data.Infrastructure.Contracts;
    using Swimmy.Entities.Membership;

    public static class UserExtensions
    {
        public static User GetSingleByUsername(
            this IEntityBaseRepository<User> userRepository,
            string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.UserName == username);
        }
    }
}