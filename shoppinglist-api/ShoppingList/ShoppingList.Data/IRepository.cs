using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingList.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        #region Create

        int Create(T entity);

        Task<int> CreateAsync(T entity);

        int CreateWithInt32Identity(T entity);

        Task<int> CreateWithInt32IdentityAsync(T entity);

        long CreateWithInt64Identity(T entity);

        Task<long> CreateWithInt64IdentityAsync(T entity);

        void Create(IEnumerable<T> entities);

        Task CreateAsync(IEnumerable<T> entities);

        #endregion Create

        #region Read

        T GetEntity(Expression<Func<T, bool>> predicate);

        Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate);

        PaginatedList<T> GetEntities(System.Linq.IQueryable<T> dataSource, int dataIndex, int dataSize);

        Task<PaginatedList<T>> GetEntitiesAsync(System.Linq.IQueryable<T> dataSource, int dataIndex, int dataSize);

        IQueryable<T> Entities();
        #endregion Read

        #region Update
        /// <summary>
        /// Synchronous Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of the updated records</returns>
        int Update(T entity);

        /// <summary>
        /// Asynchronous Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of the updated records</returns>
        Task<int> UpdateAsync(T entity);

        void Update(IEnumerable<T> entities);

        Task UpdateAsync(IEnumerable<T> entities);
        #endregion Update

        #region Delete
        /// <summary>
        /// Synchronous Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of the deleted records</returns>
        int Delete(T entity);

        /// <summary>
        /// Asynchronous Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of the deleted records</returns>
        Task<int> DeleteAsync(T entity);

        /// <summary>
        /// Synchronous Delete
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// Asynchronous Delete
        /// </summary>
        /// <param name="entities"></param>
        Task DeleteAsync(IEnumerable<T> entities);
        #endregion Delete
    }
}
