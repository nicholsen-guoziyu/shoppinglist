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
        Task<long> CreateShopping(Shopping shopping);

        Task<Shopping> GetShopping(DateTime shoppingDate);

        Task<int> UpdateShopping(Shopping shopping);

        Task<int> DeleteShopping(long shoppingId);

        Task<int> CreateShoppingItem(ShoppingItem shoppingItem);

        Task<PaginatedList<ShoppingItem>> GetShoppingItems(long shoppingId);

        Task<PaginatedList<ShoppingItem>> GetShoppingItems(DateTime shoppingDate);

        Task<ShoppingItem> GetShoppingItem(long ShoppingItemId);

        Task<int> UpdateShoppingItem(ShoppingItem shoppingItem);

        Task<int> DeleteShoppingItem(ShoppingItem shoppingItem);

        Task<int> CreateShoppingItemImage(ShoppingItemImage shoppingItemImage);

        Task<int> UpdateShoppingItemImage(ShoppingItemImage shoppingItemImage);

        Task<int> DeleteShoppingItemImage(ShoppingItemImage shoppingItemImage);
    }
}
