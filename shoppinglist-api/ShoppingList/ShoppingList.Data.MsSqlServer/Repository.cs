
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using ShoppingList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data.MsSqlServer
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public string ConnectionString { get; set; }


        private DataConnection GetDataConnection()
        {
            var dataConnection = new DataConnection(new SqlServerDataProvider(ProviderName.SqlServer, 
                                            SqlServerVersion.v2008), ConnectionString);
            return dataConnection;
        }

        public int Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int totalRecords = 0;
            
            using (var dataConnection = GetDataConnection())
            {
                totalRecords = dataConnection.Insert(entity);
            }
            
            return totalRecords;
        }

        public async Task<int> CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int totalRecords = 0;

            using (var dataConnection = GetDataConnection())
            {
                totalRecords = await dataConnection.InsertAsync(entity);
            }

            return totalRecords;
        }

        public void Create(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public int CreateWithInt32Identity(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateWithInt32IdentityAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public long CreateWithInt64Identity(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<long> CreateWithInt64IdentityAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Entities()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
