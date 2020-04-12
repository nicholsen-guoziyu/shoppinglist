using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingList.Data
{
    public interface IRepository<T>
    {
        #region Create
        void Add(T entity);

        void AddRange(IEnumerable<T> entity);
        #endregion Create

        #region Read
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Implement the below method with care to not return a lot of records to avoid overloading the systems
        /// </summary>
        /// <returns></returns>
        Task<List<T>> ListAsync();

        Task<List<T>> ListAsync(IQueryable<T> dataSource, int dataIndex, int dataSize);

        Task<int> GetDataCount();

        Task<int> GetDataCount(IQueryable<T> dataSource);

        IQueryable<T> Query();
        #endregion Read

        #region Update
        void Update(T entity);

        void Update(IEnumerable<T> entity);
        #endregion Update

        #region Delete
        void Remove(T entity);

        void Remove(IEnumerable<T> entity);
        #endregion Delete

        #region Save
        int SaveChanges();

        Task<int> SaveChangesAsync();
        #endregion Save
    }
}
