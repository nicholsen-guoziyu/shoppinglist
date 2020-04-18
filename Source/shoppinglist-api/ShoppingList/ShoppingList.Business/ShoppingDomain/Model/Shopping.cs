using ShoppingList.Data;
using System;

namespace ShoppingList.Business.ShoppingDomain.Model
{
    public class Shopping : BaseEntity
    {
        public long UserId { get; set; }

        public DateTime ShoppingDate { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
