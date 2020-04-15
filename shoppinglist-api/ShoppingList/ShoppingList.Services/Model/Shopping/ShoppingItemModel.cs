using System;
using System.Collections.Generic;

namespace ShoppingList.Services.Model.Shopping
{
    public class ShoppingItemModel
    {
        public long Id { get; set; }

        public int Index { get; set; }

        public string Store { get; set; }

        public string ItemName { get; set; }

        public string ItemBrand { get; set; }

        public decimal ItemQuantity { get; set; }

        public decimal ItemPrice { get; set; }

        public int ItemPriority { get; set; }

        public int ItemStatus { get; set; }

        public string ItemRemark { get; set; }

        public List<string> ItemImageUrlList { get; set; }
    }
}
