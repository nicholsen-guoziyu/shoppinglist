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
        private readonly IRepository<ShoppingItemImage> _shoppingItemImageRepository;

        public ShoppingBusiness(IRepository<Shopping> shoppingRepository, 
                                IRepository<ShoppingItem> shoppingItemRepository,
                                IRepository<ShoppingItemImage> shoppingItemImageRepository)
        {
            _shoppingRepository = shoppingRepository;
            _shoppingItemRepository = shoppingItemRepository;
            _shoppingItemImageRepository = shoppingItemImageRepository;
        }

        #region Shopping

        public async Task<long> CreateShopping(Shopping shopping)
        {
            return await _shoppingRepository.CreateWithInt64IdentityAsync(shopping);
        }

        public async Task<Shopping> GetShopping(DateTime shoppingDate)
        {
            return await _shoppingRepository.GetEntityAsync(entity => DateTime.Compare(entity.ShoppingDate.Date, shoppingDate.Date) == 0);
        }

        public Task<int> UpdateShopping(Shopping shopping)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteShopping(long shoppingId)
        {
            throw new NotImplementedException();
        }

        #endregion Shopping

        #region ShoppingItem

        public async Task<long> CreateShoppingItem(ShoppingItem shoppingItem)
        {
            return await _shoppingItemRepository.CreateWithInt64IdentityAsync(shoppingItem);
        }

        public Task<ShoppingItem> GetShoppingItem(long ShoppingItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<ShoppingItem>> GetShoppingItems(DateTime shoppingDate, int dataIndex, int dataSize)
        {
            var shopping = await GetShopping(shoppingDate);

            return await GetShoppingItems(shopping.Id, dataIndex, dataSize);
        }

        public async Task<PaginatedList<ShoppingItem>> GetShoppingItems(long shoppingId, int dataIndex, int dataSize)
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

            return await _shoppingItemRepository.GetEntitiesAsync(query, dataIndex, dataSize);
        }

        public Task<int> UpdateShoppingItem(ShoppingItem shoppingItem)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteShoppingItem(ShoppingItem shoppingItem)
        {
            throw new NotImplementedException();
        }

        #endregion ShoppingItem

        #region ShoppingItemImage

        public async Task<long> CreateShoppingItemImage(ShoppingItemImage shoppingItemImage)
        {
            return await _shoppingItemImageRepository.CreateWithInt64IdentityAsync(shoppingItemImage);
        }

        public async Task<PaginatedList<ShoppingItemImage>> GetShoppingItemImages(List<long> shoppingItemIdList, int dataIndex, int dataSize)
        {
            var count = shoppingItemIdList.Count();
            var filteredItemIdList = shoppingItemIdList.Skip((dataIndex - 1) * dataSize).Take(dataSize);
            var query = from shoppingItemImage in _shoppingItemImageRepository.Entities
                        where filteredItemIdList.Contains(shoppingItemImage.ShoppingItemId)
                        select new ShoppingItemImage
                        {
                            Id = shoppingItemImage.Id,
                            ShoppingItemId = shoppingItemImage.ShoppingItemId,
                            ImageName = shoppingItemImage.ImageName
                        };
            return new PaginatedList<ShoppingItemImage>(await _shoppingItemImageRepository.GetEntitiesAsync(query), count, dataIndex, dataSize);
        }

        public Task<int> UpdateShoppingItemImage(ShoppingItemImage shoppingItemImage)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteShoppingItemImage(ShoppingItemImage shoppingItemImage)
        {
            throw new NotImplementedException();
        }

        #endregion ShoppingItemImage
    }
}
