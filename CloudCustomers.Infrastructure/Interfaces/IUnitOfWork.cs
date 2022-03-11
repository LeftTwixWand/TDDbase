using CloudCustomers.Domain.Contracts;

namespace CloudCustomers.Infrastructure.Interfaces;

public interface IUnitOfWork<TId> : IDisposable
{
    IRepositoryAsync<T, TId> RepositoryAsync<T>() where T: AuditableEntity<TId>;
    Task<int> Commit(CancellationToken cancellationToken);
    Task<int> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
    Task Rollback();
}