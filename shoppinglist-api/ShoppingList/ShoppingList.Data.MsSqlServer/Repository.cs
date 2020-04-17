using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingList.Data.MsSqlServer
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public string ConnectionString 
        {
            //TODO make connection string dynamically by read from file
            get { return "Server=localhost;Database=ShoppingList;Trusted_Connection=True;Enlist=False;";  }
            set
            {

            }
        }

        private DataConnection GetDataProvider()
        {
            var dataConnection = new DataConnection(new SqlServerDataProvider(ProviderName.SqlServer, 
                                            SqlServerVersion.v2008), ConnectionString);
            return dataConnection;
        }

        #region Create

        public int Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int totalRecords = 0;
            
            using (var dataConnection = GetDataProvider())
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

            using (var dataConnection = GetDataProvider())
            {
                totalRecords = await dataConnection.InsertAsync(entity);
            }

            return totalRecords;
        }

        public void Create(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public int CreateWithInt32Identity(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int newId = 0;

            using (var dataConnection = GetDataProvider())
            {
                newId = dataConnection.InsertWithInt32Identity(entity);
            }

            return newId;
        }

        public async Task<int> CreateWithInt32IdentityAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int newId = 0;

            using (var dataConnection = GetDataProvider())
            {
                newId = await dataConnection.InsertWithInt32IdentityAsync(entity);
            }

            return newId;
        }

        public long CreateWithInt64Identity(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            long newId = 0;

            using (var dataConnection = GetDataProvider())
            {
                newId = dataConnection.InsertWithInt64Identity(entity);
            }

            return newId;
        }

        public async Task<long> CreateWithInt64IdentityAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            long newId = 0;

            using (var dataConnection = GetDataProvider())
            {
                newId = await dataConnection.InsertWithInt64IdentityAsync(entity);
            }

            return newId;
        }

        #endregion Create

        #region Delete

        public int Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int totalRecords = 0;

            using (var dataConnection = GetDataProvider())
            {
                totalRecords = dataConnection.Delete(entity);
            }

            return totalRecords;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int totalRecords = 0;

            using (var dataConnection = GetDataProvider())
            {
                totalRecords = await dataConnection.DeleteAsync(entity);
            }

            return totalRecords;
        }

        public async Task<int> DeleteAsync(IQueryable<T> query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            int totalRecords = 0;

            using (var dataConnection = GetDataProvider())
            {
                totalRecords = await query.DeleteAsync();
            }

            return totalRecords;
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        #endregion Delete

        #region Read

        private ITable<T> _table;

        public ITable<T> GetTable()
        {
            return new DataContext(new SqlServerDataProvider(ProviderName.SqlServer,
                                            SqlServerVersion.v2008), ConnectionString).GetTable<T>();
        }

        protected ITable<T> Table => _table ?? (_table = GetTable());

        public IQueryable<T> Entities => Table;

        public T GetEntity(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }

        public PaginatedList<T> GetEntities(System.Linq.IQueryable<T> dataSource, int dataIndex, int dataSize)
        {
            var count = dataSource.Count();
            var items = dataSource.Skip((dataIndex - 1) * dataSize).Take(dataSize).ToList();
            return new PaginatedList<T>(items, count, dataIndex, dataSize);
        }

        public async Task<PaginatedList<T>> GetEntitiesAsync(System.Linq.IQueryable<T> dataSource, int dataIndex, int dataSize)
        {
            var count = await dataSource.CountAsync();
            var items = await dataSource.Skip((dataIndex - 1) * dataSize).Take(dataSize).ToListAsync();
            return new PaginatedList<T>(items, count, dataIndex, dataSize);
        }

        public async Task<List<T>> GetEntitiesAsync(System.Linq.IQueryable<T> dataSource)
        {
            return await dataSource.ToListAsync();
        }

        #endregion Read

        #region Update
        public int Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int totalRecords = 0;

            using (var dataConnection = GetDataProvider())
            {
                totalRecords = dataConnection.Update(entity);
            }

            return totalRecords;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int totalRecords = 0;

            using (var dataConnection = GetDataProvider())
            {
                totalRecords = await dataConnection.UpdateAsync(entity);
            }

            return totalRecords;
        }

        public void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
        #endregion Update
    }
}
