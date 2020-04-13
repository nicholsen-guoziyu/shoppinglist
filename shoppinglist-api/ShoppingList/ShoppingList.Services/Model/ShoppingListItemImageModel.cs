namespace ShoppingList.Services.Model
{
    public class ShoppingListItemImageModel
    {
        public long Id { get; set; }

        public long ShoppingListItemId { get; set; }

        public string ImageName { get; set; }
    }
}
