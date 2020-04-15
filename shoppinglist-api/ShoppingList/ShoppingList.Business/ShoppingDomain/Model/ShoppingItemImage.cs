using ShoppingList.Data;
using System;

namespace ShoppingList.Business.ShoppingDomain.Model
{
    public class ShoppingItemImage : BaseEntity
    {
        public long Id { get; set; }

        public long ShoppingItemId { get; set; }

        public string ImageName { get; set; }

        public byte[] ImageFile { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
