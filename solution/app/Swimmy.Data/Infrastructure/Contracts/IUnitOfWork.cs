namespace Swimmy.Data.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}