namespace ShoppingList.Services.Model.Shopping
{
    public class ShoppingItemCreateRequestModel : BaseShoppingItemModel
    {
        public string ImageName { get; set; }

        public byte[] ImageFile { get; set; }
    }
}
