using System.Linq.Expressions;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EasyRank.Services.UnitTests.Mocks
{
    public class RepoMock : IRepository
    {
        public RepoMock(EasyRankDbContext context)
        {
            this.Context = context;
        }

        protected DbContext Context { get; set; }

        public async Task AddAsync<T>(T entity)
            where T : class
        {
            await this.DbSet<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities)
            where T : class
        {
            await this.DbSet<T>().AddRangeAsync(entities);
        }

        public IQueryable<T> All<T>()
            where T : class
        {
            return this.DbSet<T>().AsQueryable();
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> search)
            where T : class
        {
            return this.DbSet<T>()
                .Where(search);
        }

        public IQueryable<T> AllReadonly<T>()
            where T : class
        {
            return this.DbSet<T>()
                .AsNoTracking();
        }

        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search)
            where T : class
        {
            return this.DbSet<T>()
                .Where(search)
                .AsNoTracking();
        }

        public async Task DeleteAsync<T>(object id)
            where T : class
        {
            T entity = await this.GetByIdAsync<T>(id);

            this.Delete<T>(entity);
        }

        public void Delete<T>(T entity)
            where T : class
        {
            EntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        public void Detach<T>(T entity)
            where T : class
        {
            EntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public async Task<T> GetByIdAsync<T>(object id)
            where T : class
        {
            return await this.DbSet<T>().FindAsync(id);
        }

        public async Task<T> GetByIdsAsync<T>(object[] id)
            where T : class
        {
            return await this.DbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }

        public void Update<T>(T entity)
            where T : class
        {
            this.DbSet<T>().Update(entity);
        }

        public void UpdateRange<T>(IEnumerable<T> entities)
            where T : class
        {
            this.DbSet<T>().UpdateRange(entities);
        }

        public void DeleteRange<T>(IEnumerable<T> entities)
            where T : class
        {
            this.DbSet<T>().RemoveRange(entities);
        }

        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause)
            where T : class
        {
            IQueryable<T> entities = this.All<T>(deleteWhereClause);
            this.DeleteRange(entities);
        }


        protected DbSet<T> DbSet<T>()
            where T : class
        {
            return this.Context.Set<T>();
        }
    }
}
