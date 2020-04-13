using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data
{
    interface IPagination<T> where T : BaseEntity
    {
        Task<List<T>> ListAsync(IQueryable<T> dataSource, int dataIndex, int dataSize);

        Task<int> GetDataCount(IQueryable<T> dataSource);
    }
}
