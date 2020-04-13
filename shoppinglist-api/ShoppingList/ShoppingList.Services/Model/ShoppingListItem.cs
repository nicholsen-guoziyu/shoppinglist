using ShoppingList.Data;

namespace ShoppingList.Services.Model
{
    public class ShoppingListItem : BaseEntity
    {
        public long Id { get; set; }

        public string Store { get; set; }

        public string ItemName { get; set; }

        public string ItemBrand { get; set; }

        public string ItemQuantity { get; set; }

        public decimal ItemPrice { get; set; }

        public int ItemPriority { get; set; }

        public string ItemRemark { get; set; }
    }
}
