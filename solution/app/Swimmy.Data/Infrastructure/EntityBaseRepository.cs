namespace Swimmy.Data.Infrastructure
{
    using global::System;
    using global::System.Data.Entity;
    using global::System.Data.Entity.Infrastructure;
    using global::System.Linq;
    using global::System.Linq.Expressions;

    using Swimmy.Data.Infrastructure.Contracts;
    using Swimmy.Entities.Contracts;

    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        private SwimmingResultsContext dataContext;

        public virtual IQueryable<T> GetAll()
        {
            return this.DbContext.Set<T>();
        }

        public virtual IQueryable<T> All => this.GetAll();

        public virtual IQueryable<T> AllIncluding(
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = this.DbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T GetSingle(
            int id)
        {
            return this.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public virtual IQueryable<T> FindBy(
            Expression<Func<T, bool>> predicate)
        {
            return this.DbContext.Set<T>().Where(predicate);
        }

        public virtual void Add(
            T entity)
        {
            this.DbContext.Set<T>().Add(entity);
        }

        public virtual void Edit(
            T entity)
        {
            DbEntityEntry dbEntityEntry = this.DbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(
            T entity)
        {
            DbEntityEntry dbEntityEntry = this.DbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        #region Properties

        protected IDbFactory DbFactory { get; }

        protected SwimmingResultsContext DbContext => this.dataContext ?? (this.dataContext = this.DbFactory.Init());

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
        }

        #endregion
    }
}