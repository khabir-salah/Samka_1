
using Domain.Aggregates.PaymentAggregate.Enum;
using Domain.Sheared.ValueObjects;

namespace Domain.Aggregates.PaymentAggregate.Entities
{
    public class Invoice
    {
        public Guid BookingId { get; private set; }
        public Money Amount { get; private set; }
        public InvoiceStatus status { get; private set; }
        public DateTime DueDate { get; private set; }

        public Invoice(Guid bookingId, Money amount, InvoiceStatus status, DateTime dueDate)
        {
            BookingId = bookingId;
            Amount = amount;
            this.status = status;
            DueDate = dueDate;
        }

        public Invoice() { }
    }
}
