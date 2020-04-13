using System;

namespace ShoppingList.Services.Model.Shopping
{
    public class ShoppingListItemImageModel
    {
        public long Id { get; set; }

        public long ShoppingListItemId { get; set; }

        public string ImageName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
