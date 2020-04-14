using ShoppingList.Business.ShoppingDomain.Model;
using ShoppingList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Business.ShoppingDomain
{
    public class ShoppingBusiness : IShoppingBusiness
    {
        private readonly IRepository<Shopping> _shoppingRepository;
        private readonly IRepository<ShoppingItem> _shoppingItemRepository;

        public ShoppingBusiness(IRepository<Shopping> shoppingRepository, IRepository<ShoppingItem> shoppingItemRepository)
        {
            _shoppingRepository = shoppingRepository;
            _shoppingItemRepository = shoppingItemRepository;
        }

        public Task<long> CreateShopping(Shopping shopping)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateShoppingItem(ShoppingItem shoppingItem)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateShoppingItemImage(ShoppingItemImage shoppingItemImage)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteShopping(long shoppingId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteShoppingItem(ShoppingItem shoppingItem)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteShoppingItemImage(ShoppingItemImage shoppingItemImage)
        {
            throw new NotImplementedException();
        }

        public Task<Shopping> GetShopping(DateTime shoppingDate)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingItem> GetShoppingItem(long ShoppingItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<ShoppingItem>> GetShoppingItems(long shoppingId)
        {
            var query = _shoppingItemRepository.Entities;

            if (shoppingId > 0)
            {
                query = query.Where(a => a.Id == shoppingId);
            }
            else
            {
                throw new ArgumentException("Invalid argument provided");
            }
            
            return await _shoppingItemRepository.GetEntitiesAsync(query, 0, int.MaxValue);
        }

        public async Task<PaginatedList<ShoppingItem>> GetShoppingItems(DateTime shoppingDate)
        {
            var shopping = await GetShopping(shoppingDate);

            return await GetShoppingItems(shopping.Id);
        }

        public Task<int> UpdateShopping(Shopping shopping)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateShoppingItem(ShoppingItem shoppingItem)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateShoppingItemImage(ShoppingItemImage shoppingItemImage)
        {
            throw new NotImplementedException();
        }
    }
}
