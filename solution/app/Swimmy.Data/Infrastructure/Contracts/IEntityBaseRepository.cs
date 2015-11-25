namespace Swimmy.Data.Infrastructure.Contracts
{
    using global::System;
    using global::System.Linq;
    using global::System.Linq.Expressions;

    using Swimmy.Entities.Contracts;

    public interface IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllIncluding(
            params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll();

        T GetSingle(
            int id);

        IQueryable<T> FindBy(
            Expression<Func<T, bool>> predicate);

        void Add(
            T entity);

        void Delete(
            T entity);

        void Edit(
            T entity);
    }
}