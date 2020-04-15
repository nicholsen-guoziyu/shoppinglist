using ShoppingList.Business.ShoppingDomain.Model;
using ShoppingList.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Business.ShoppingDomain
{
    public interface IShoppingBusiness
    {
        #region Shopping

        Task<long> CreateShopping(Shopping shopping);

        Task<Shopping> GetShopping(DateTime shoppingDate);

        Task<int> UpdateShopping(Shopping shopping);

        Task<int> DeleteShopping(long shoppingId);

        #endregion Shopping

        #region ShoppingItem

        Task<int> CreateShoppingItem(ShoppingItem shoppingItem);

        Task<PaginatedList<ShoppingItem>> GetShoppingItems(DateTime shoppingDate, int dataIndex, int dataSize);

        Task<PaginatedList<ShoppingItem>> GetShoppingItems(long shoppingId, int dataIndex, int dataSize);

        Task<ShoppingItem> GetShoppingItem(long ShoppingItemId);

        Task<int> UpdateShoppingItem(ShoppingItem shoppingItem);

        Task<int> DeleteShoppingItem(ShoppingItem shoppingItem);

        #endregion ShoppingItem

        #region ShoppingItemImage

        Task<int> CreateShoppingItemImage(ShoppingItemImage shoppingItemImage);

        Task<PaginatedList<ShoppingItemImage>> GetShoppingItemImages(List<long> shoppingItems, int dataIndex, int dataSize);

        Task<int> UpdateShoppingItemImage(ShoppingItemImage shoppingItemImage);

        Task<int> DeleteShoppingItemImage(ShoppingItemImage shoppingItemImage);

        #endregion ShoppingItemImage
    }
}
