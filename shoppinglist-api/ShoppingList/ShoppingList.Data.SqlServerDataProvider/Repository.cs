using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShoppingList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data.SqlServerDataProvider
{
    public class Repository<T> : IRepository<T> where T: class
    {
        public Repository(DatabaseContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        protected DatabaseContext Context { get; }

        protected DbSet<T> DbSet { get; }

        #region Create
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            DbSet.AddRange(entity);
        }
        #endregion Create

        #region Read
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> ListAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<T>> ListAsync(IQueryable<T> dataSource, int dataIndex, int dataSize)
        {
            var items = await dataSource.Skip((dataIndex - 1) * dataSize).Take(dataSize).ToListAsync();
            return items;
        }

        public async Task<int> GetDataCount()
        {
            var dataCount = await Query().CountAsync();
            return dataCount;
        }

        public async Task<int> GetDataCount(IQueryable<T> dataSource)
        {
            var dataCount = await dataSource.CountAsync();
            return dataCount;
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }
        #endregion Read

        #region Update
        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
        public void Update(IEnumerable<T> entity)
        {
            DbSet.UpdateRange(entity);
        }
        #endregion Update

        #region Delete
        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Remove(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
        #endregion Delete

        #region Save
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await Context.SaveChangesAsync();
            return result;
        }
        #endregion Save

        #region Transaction
        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }
        #endregion Transaction
    }
}
