using Domain.Sheared.Entities;

namespace Domain.Aggregates.MarketPlaceAggregate.Entities
{
    public class Review : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public Guid BuyerId { get; private set; }
        public Guid SellerId { get; private set; }
        public string Comment { get; private set; }
        public double Rating { get; private set; }

        public Review() { }

        public Review(Guid orderId, Guid buyerId, Guid sellerId, string comment, double rating)
        {
            OrderId = orderId;
            BuyerId = buyerId;
            SellerId = sellerId;
            Comment = comment;
            Rating = rating;
        }
    }
}
