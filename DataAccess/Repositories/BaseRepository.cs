using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeVsVirus.DataAccess.DatabaseContext;
using WeVsVirus.DataAccess.Specifications;
using WeVsVirus.Models;

namespace WeVsVirus.DataAccess.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        public BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        protected ApplicationDbContext DbContext { get; }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<IDictionary<TK, IEnumerable<T>>> DictionaryGroupedAsync<TK>(IGroupingSpecification<T, TK> spec)
        {
            return (await ApplyGroupingSpecificationAsync(spec)).ToDictionary(group => group.Key, group => group.Select(x => x));
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            //await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyCollection<T>> AddRangeAsync(IReadOnlyCollection<T> entities)
        {
            await DbContext.Set<T>().AddRangeAsync(entities);
            //await DbContext.SaveChangesAsync();

            return entities;
        }

        //public async Task UpdateAsync(T entity)
        //{
        //    DbContext.Entry(entity).State = EntityState.Modified;
        //    await DbContext.SaveChangesAsync();
        //}

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            //await DbContext.SaveChangesAsync();
        }
        public void DeleteRange(IReadOnlyCollection<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
        }

        public virtual async Task<bool> AnyAsync(object id)
        {
            return await DbContext.Set<T>().FindAsync(id) != null;
        }

        public async Task<bool> AnyAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).AnyAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(DbContext.Set<T>().AsQueryable(), spec);
        }

        private async Task<IEnumerable<IGrouping<TK, T>>> ApplyGroupingSpecificationAsync<TK>(IGroupingSpecification<T, TK> spec)
        {
            // must return IEnumerable since GroupBy computation on database is not supported yet in EF Core 3.0
            // TODO: change as soon EF Core supports GroupBy
            return await SpecificationEvaluator<T>.GetGroupingEnumerableAsync(DbContext.Set<T>().AsQueryable(), spec);
        }

        public IQueryable<T> AsQueryAble()
        {
            return DbContext.Set<T>();
        }
    }
}
