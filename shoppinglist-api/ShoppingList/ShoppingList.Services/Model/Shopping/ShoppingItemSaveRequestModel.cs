namespace ShoppingList.Services.Model.Shopping
{
    public class ShoppingItemSaveRequestModel : BaseShoppingItemModel
    {
        public long ShoppingId { get; set; }

        public string ImageName { get; set; }
    }
}
