
using CloudCustomers.Domain.Contracts;
using CloudCustomers.Infrastructure.Interfaces;

namespace CloudCustomers.Infrastructure.Repositories;

public class RepositoryAsync<T, TId> : IRepositoryAsync<T, TId> where T : class, IEntity<TId>
{
    public IQueryable<T> Entities { get; }
    public Task<T> GetByIdAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }
}