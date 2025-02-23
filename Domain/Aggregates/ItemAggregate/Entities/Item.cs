using Domain.Aggregates.MarketPlaceAggregate.Enum;
using Domain.Sheared.Entities;
using Domain.Sheared.ValueObjects;

namespace Domain.Aggregates.MarketPlaceAggregate.Entities
{
    public class Item : AuditableEntity<Guid>
    {
        public Guid SellerId { get; private set; }
        public string Title { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public Guid CategoryId { get; private set; }
        public decimal Price { get; private set; }
        public ItemCondition Condition { get; private set; }
        public Address Address { get; private set; } = default!;
        public ItemStatus Status { get; private set; }


        public Item() { }
        public Item(Guid sellerId, string title, string description, Guid categoryId, decimal price, ItemCondition condition, Address address, ItemStatus status)
        {
            SellerId = sellerId;
            Title = title;
            Description = description;
            CategoryId = categoryId;
            Price = price;
            Condition = condition;
            Address = address;
            Status = status;
        }

        public void UpdateItem(string title, string description, decimal price, ItemCondition condition, Address address, ItemStatus status)
        {
            Title = title ?? Title;
            Description = description ?? Description;
            Price = price;
            Condition = condition;
            Address = address ?? Address;
            Status = status;
        }
    }
}
