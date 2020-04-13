using System;

namespace ShoppingList.Services.Model.Shopping
{
    public class ShoppingListModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
