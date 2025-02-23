

namespace Domain.Sheared.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = default!;
    }
}
