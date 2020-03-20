using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeVsVirus.Models;
using WeVsVirus.DataAccess.Repositories;
using WeVsVirus.DataAccess.DatabaseContext;

namespace WeVsVirus.DataAccess
{
    public interface IUnitOfWork
    {
        IAsyncRepository<T> Repository<T>() where T : BaseEntity;
        int Complete();
        Task<int> CompleteAsync();

        ApplicationDbContext DbContext { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            DbContext = dbContext;
            ServiceProvider = serviceProvider;
        }
        public ApplicationDbContext DbContext { get; }

        public IServiceProvider ServiceProvider { get; }

        public IAsyncRepository<T> Repository<T>() where T : BaseEntity
        {
            return ServiceProvider.GetRequiredService<IAsyncRepository<T>>();
        }

        public int Complete()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
