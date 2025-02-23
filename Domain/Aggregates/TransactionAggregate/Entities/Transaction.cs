using Domain.Aggregates.PaymentAggregate.Enum;
using Domain.Sheared.ValueObjects;

namespace Domain.Aggregates.PaymentAggregate.Entities
{
    public class Transaction
    {
        public Guid UserID { get; private set; }
        public Money Amount { get; private set; } = default!;
        public TransactionStatus Status { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public Transaction() { }

        public Transaction(Guid userID, Money amount, TransactionStatus status, PaymentMethod paymentMethod)
        {
            UserID = userID;
            Amount = amount;
            Status = status;
            PaymentMethod = paymentMethod;
        }
    }
}

