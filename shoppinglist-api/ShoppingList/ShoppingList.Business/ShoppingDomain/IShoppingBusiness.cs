using ShoppingList.Business.ShoppingDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Business.ShoppingDomain
{
    interface IShoppingBusiness
    {
        int CreateShopping(Shopping shopping);

        int CreateShoppingItem(IEnumerable<ShoppingItem> shoppingItems);
    }
}
