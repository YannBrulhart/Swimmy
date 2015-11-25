namespace Swimmy.Data.Infrastructure
{
    using Swimmy.Data.Infrastructure.Contracts;

    public class DbFactory : Disposable,
                             IDbFactory
    {
        SwimmingResultsContext dbContext;

        public SwimmingResultsContext Init()
        {
            return this.dbContext ?? (this.dbContext = new SwimmingResultsContext());
        }

        protected override void DisposeCore()
        {
            if (this.dbContext != null)
            {
                this.dbContext.Dispose();
            }
        }
    }
}