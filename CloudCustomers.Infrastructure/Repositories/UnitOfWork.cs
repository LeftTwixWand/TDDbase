using CloudCustomers.Domain.Contracts;
using CloudCustomers.Infrastructure.Interfaces;

namespace CloudCustomers.Infrastructure.Repositories;

public class UnitOfWork<TId> : IUnitOfWork<TId>
{
    public void Dispose()
    {
        
        
    }

    public IRepositoryAsync<T, TId> RepositoryAsync<T>() where T : AuditableEntity<TId>
    {
        throw new NotImplementedException();
    }

    public Task<int> Commit(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
    {
        throw new NotImplementedException();
    }

    public Task Rollback()
    {
        throw new NotImplementedException();
    }
}