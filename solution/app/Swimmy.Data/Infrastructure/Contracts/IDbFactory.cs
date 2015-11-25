namespace Swimmy.Data.Infrastructure.Contracts
{
    using global::System;

    public interface IDbFactory : IDisposable
    {
        SwimmingResultsContext Init();
    }
}