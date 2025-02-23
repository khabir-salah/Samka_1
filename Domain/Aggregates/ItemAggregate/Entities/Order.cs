

using Domain.Aggregates.MarketPlaceAggregate.Enum;
using Domain.Sheared.Entities;
using Domain.Sheared.ValueObjects;

namespace Domain.Aggregates.MarketPlaceAggregate.Entities
{
    public class Order : AuditableEntity<Guid>
    {
        public Guid BuyerId { get; private set; }
        public Guid SellerId { get; private set; }
        public Guid ItemId { get; private set; }
        public Address DeliveryAddress { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public Money Amount { get; private set; }
        public string OrderReference {  get; private set; }

        public Order() { }

        public Order(Guid buyerId, Guid sellerId, Guid itemId, Address deliveryAddress, OrderStatus orderStatus, Money amount)
        {
            BuyerId = buyerId;
            SellerId = sellerId;
            ItemId = itemId;
            DeliveryAddress = deliveryAddress;
            OrderStatus = orderStatus;
            Amount = amount;
        }
    }
}