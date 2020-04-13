using ShoppingList.Data;
using System;

namespace ShoppingList.Services.Domain.Shopping
{
    public class ShoppingListItemImage : BaseEntity
    {
        public long Id { get; set; }

        public long ShoppingListItemId { get; set; }

        public string ImageName { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
