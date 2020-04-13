using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services.Domain.Shopping
{
    public class ShoppingList
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
