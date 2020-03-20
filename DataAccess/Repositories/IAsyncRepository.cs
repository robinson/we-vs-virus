using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeVsVirus.DataAccess.Specifications;
using WeVsVirus.Models.Entities;

namespace WeVsVirus.DataAccess.Repositories
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(object id);
        Task<T> GetByAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<IDictionary<TK, IEnumerable<T>>> DictionaryGroupedAsync<TK>(IGroupingSpecification<T, TK> spec);
        Task<T> AddAsync(T entity);
        Task<IReadOnlyCollection<T>> AddRangeAsync(IReadOnlyCollection<T> entities);
        //Task UpdateAsync(T entity);
        void Delete(T entity);
        void DeleteRange(IReadOnlyCollection<T> entities);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<bool> AnyAsync(object id);
        Task<bool> AnyAsync(ISpecification<T> spec);
        IQueryable<T> AsQueryAble();
    }
}
