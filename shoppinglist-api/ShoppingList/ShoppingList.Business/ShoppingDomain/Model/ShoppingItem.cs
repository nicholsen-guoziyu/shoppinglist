using LinqToDB.Mapping;
using ShoppingList.Data;
using System;

namespace ShoppingList.Business.ShoppingDomain.Model
{
    [Table(Name = "ShoppingItem")] //TODO to be moved to metadata configuration to make this class loosely coupled from linqtodb
    public class ShoppingItem : BaseEntity
    {
        [PrimaryKey, Identity]
        public long Id { get; set; }

        [Column(Name = "ShoppingId"), NotNull]
        public long ShoppingId { get; set; }

        [Column(Name = "Store"), NotNull]
        public string Store { get; set; }

        [Column(Name = "ItemName"), NotNull]
        public string ItemName { get; set; }

        [Column(Name = "ItemBrand"), NotNull]
        public string ItemBrand { get; set; }

        [Column(Name = "ItemQuantity"), NotNull]
        public decimal ItemQuantity { get; set; }

        [Column(Name = "ItemPrice"), NotNull]
        public decimal ItemPrice { get; set; }

        [Column(Name = "ItemPriority"), NotNull]
        public int ItemPriority { get; set; }

        [Column(Name = "ItemStatus"), NotNull]
        public int ItemStatus { get; set; }

        [Column(Name = "ItemRemark"), NotNull]
        public string ItemRemark { get; set; }

        [Column(Name = "CreatedBy"), NotNull]
        public long CreatedBy { get; set; }

        [Column(Name = "CreatedOnUtc"), NotNull]
        public DateTime CreatedOnUtc { get; set; }

        [Column(Name = "ModifiedBy"), NotNull]
        public long ModifiedBy { get; set; }

        [Column(Name = "ModifiedOnUtc"), NotNull]
        public DateTime ModifiedOnUtc { get; set; }
    }
}
