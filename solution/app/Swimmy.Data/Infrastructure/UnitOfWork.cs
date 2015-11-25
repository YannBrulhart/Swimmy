namespace Swimmy.Data.Infrastructure
{
    using Swimmy.Data.Infrastructure.Contracts;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;

        private SwimmingResultsContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public SwimmingResultsContext DbContext => this.dbContext ?? (this.dbContext = this.dbFactory.Init());

        public void Commit()
        {
            this.DbContext.Commit();
        }
    }
}