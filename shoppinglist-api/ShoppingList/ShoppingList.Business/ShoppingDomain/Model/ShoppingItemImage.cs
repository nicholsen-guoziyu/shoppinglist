using LinqToDB.Mapping;
using ShoppingList.Data;
using System;

namespace ShoppingList.Business.ShoppingDomain.Model
{
    [Table(Name = "ShoppingItemImage")]//TODO to be moved to metadata configuration to make this class loosely coupled from linqtodb
    public class ShoppingItemImage : BaseEntity
    {
        [PrimaryKey, Identity]
        public long Id { get; set; }

        [Column(Name = "ShoppingItemId"), NotNull]
        public long ShoppingItemId { get; set; }

        [Column(Name = "ImageName"), NotNull]
        public string ImageName { get; set; }

        [Column(Name = "ImageFile"), NotNull]
        public byte[] ImageFile { get; set; }

        [Column(Name = "CreatedBy"), NotNull]
        public long CreatedBy { get; set; }

        [Column(Name = "CreatedOnUtc"), NotNull]
        public DateTime CreatedOnUtc { get; set; }
    }
}
