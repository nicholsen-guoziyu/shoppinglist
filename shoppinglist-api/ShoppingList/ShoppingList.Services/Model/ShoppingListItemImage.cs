using ShoppingList.Data;

namespace ShoppingList.Services.Model
{
    public class ShoppingListItemImage : BaseEntity
    {
        public long Id { get; set; }

        public long ShoppingListItemId { get; set; }

        public string ImageName { get; set; }
    }
}
