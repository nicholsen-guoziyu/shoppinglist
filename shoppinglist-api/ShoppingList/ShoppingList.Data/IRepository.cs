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

        void Create(IEnumerable<T> entity);

        Task CreateAsync(IEnumerable<T> entity);

        #endregion Create

        #region Read

        T GetEntity(Expression<Func<T, bool>> predicate);

        Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Implement the below method with care to not return a lot of records to avoid overloading the systems
        /// </summary>
        /// <returns></returns>
        Task<List<T>> ListAsync();

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

        void Update(IEnumerable<T> entity);

        Task UpdateAsync(IEnumerable<T> entity);
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
        /// <param name="entity"></param>
        void Delete(IEnumerable<T> entity);

        /// <summary>
        /// Asynchronous Delete
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(IEnumerable<T> entity);
        #endregion Delete
    }
}
