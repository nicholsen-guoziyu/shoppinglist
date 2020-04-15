using ShoppingList.Data;
using System;

namespace ShoppingList.Business.ShoppingDomain.Model
{
    public class ShoppingItem : BaseEntity
    {
        public long Id { get; set; }

        public long ShoppingId { get; set; }

        public string Store { get; set; }

        public string ItemName { get; set; }

        public string ItemBrand { get; set; }

        public decimal ItemQuantity { get; set; }

        public decimal ItemPrice { get; set; }

        public int ItemPriority { get; set; }

        public int ItemStatus { get; set; }

        public string ItemRemark { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedOnUtc { get; set; }
    }
}
