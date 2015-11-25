namespace Swimmy.Data
{
    using global::System.Data.Entity;
    using global::System.Data.Entity.ModelConfiguration.Conventions;

    using Swimmy.Data.Business;
    using Swimmy.Data.System;
    using Swimmy.Entities.Business;
    using Swimmy.Entities.Membership;

    public class SwimmingResultsContext : DbContext
    {
        public SwimmingResultsContext()
            : base("swimResult")
        {
            Database.SetInitializer<SwimmingResultsContext>(null);
        }

        public IDbSet<Club> ClubSet { get; set; }

        public IDbSet<Swimmer> SwimmerSet { get; set; }

        public IDbSet<User> UserSet { get; set; }

        public IDbSet<UserRole> UserRoleSet { get; set; }

        public IDbSet<Role> RoleSet { get; set; }

        public IDbSet<Discipline> DisciplineSet { get; set; }

        public IDbSet<Meeting> MeetingsSet { get; set; }

        public IDbSet<Result> ResultSet { get; set; }

        public virtual void Commit()
        {
            this.SaveChanges();
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        ///             before the model has been locked down and used to initialize the context.  The default
        ///             implementation of this method does nothing, but it can be overridden in a derived class
        ///             such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        ///             is created.  The model for that context is then cached and is for all further instances of
        ///             the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///             property on the given ModelBuidler, but note that this can seriously degrade performance.
        ///             More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///             classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(
            DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new DisciplineConfiguration());
            modelBuilder.Configurations.Add(new MeetingConfiguration());
            modelBuilder.Configurations.Add(new ClubConfiguration());
            modelBuilder.Configurations.Add(new SwimmerConfiguration());
            modelBuilder.Configurations.Add(new ResultConfiguration());
        }
    }
}