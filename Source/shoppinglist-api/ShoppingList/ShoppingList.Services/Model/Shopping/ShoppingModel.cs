using System;
using System.Collections.Generic;

namespace ShoppingList.Services.Model.Shopping
{
    public class ShoppingModel
    {
        public long Id { get; set; }

        public List<ShoppingItemModel> ShoppingItemModelList { get; set; }
    }
}
