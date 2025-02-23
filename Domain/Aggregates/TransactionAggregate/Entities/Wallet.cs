using Domain.Sheared.ValueObjects;
namespace Domain.Aggregates.PaymentAggregate.Entities
{
    public class Wallet
    {
        public Guid UserId { get; private set; }
        public Money Amount { get; private set; }
    }
}
