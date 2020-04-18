using ShoppingList.Data;
using System;

namespace ShoppingList.Business.UserDomain.Model
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
