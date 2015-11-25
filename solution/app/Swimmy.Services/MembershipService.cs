namespace Swimmy.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;

    using Swimmy.Data.Extensions;
    using Swimmy.Data.Infrastructure.Contracts;
    using Swimmy.Entities.Membership;
    using Swimmy.Services.Contracts;

    public class MembershipService : IMembershipService
    {
        private readonly IEncryptionService encryptionService;

        private readonly IEntityBaseRepository<Role> roleRepository;

        private readonly IUnitOfWork unitOfWork;

        private readonly IEntityBaseRepository<User> userRepository;

        private readonly IEntityBaseRepository<UserRole> userRoleRepository;

        public MembershipService(IEntityBaseRepository<User> userRepository,
                                 IEntityBaseRepository<Role> roleRepository,
                                 IEntityBaseRepository<UserRole> userRoleRepository,
                                 IEncryptionService encryptionService,
                                 IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
            this.encryptionService = encryptionService;
            this.unitOfWork = unitOfWork;
        }

        public MembershipContext ValidateUser(
            string username,
            string password)
        {
            var membershipContext = new MembershipContext();

            var user = this.userRepository.GetSingleByUsername(username);

            if (user != null && IsUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.UserName);
                membershipContext.User = user;

                var identity = new GenericIdentity(user.UserName);
                membershipContext.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name).ToArray());
            }

            return membershipContext;
        }

        public User CreateUser(
            string username,
            string password,
            string email,
            int[] roles)
        {
            var existingUser = this.userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = this.encryptionService.CreateSalt();

            var user = new User
                           {
                               DateCreated = DateTime.Now,
                               Email = email,
                               HashedPassword = this.encryptionService.EncryptPassword(password, passwordSalt),
                               Salt = passwordSalt,
                               IsLocked = false,
                               UserName = username
                           };

            this.userRepository.Add(user);

            this.unitOfWork.Commit();

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    AddUserToRole(user, role);
                }
            }

            this.unitOfWork.Commit();

            return user;
        }

        public User GetUser(
            int userId)
        {
            return this.userRepository.GetSingle(userId);
        }

        public List<Role> GetUserRoles(
            string username)
        {
            var roles = new List<Role>();

            var existingUser = this.userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                roles.AddRange(existingUser.UserRoles.Select(userRole => userRole.Role));
            }

            return roles.Distinct().ToList();
        }

        private void AddUserToRole(
            User user,
            int roleId)
        {
            var role = this.roleRepository.GetSingle(roleId);
            if (role == null)
            {
                throw new ApplicationException("Role does not exist!");
            }

            var userRole = new UserRole
                               {
                                   RoleId = role.Id,
                                   UserId = user.Id
                               };

            this.userRoleRepository.Add(userRole);
        }

        private bool IsPasswordValid(
            User user,
            string password)
        {
            return string.Equals(this.encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }

        private bool IsUserValid(
            User user,
            string password)
        {
            return !user.IsLocked && this.IsPasswordValid(user, password);
        }
    }
}