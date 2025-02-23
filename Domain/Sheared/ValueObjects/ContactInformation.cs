namespace Domain.Sheared.ValueObjects
{
    public class ContactInformation
    {
        public string PhoneNumber { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public Address Address { get; private set; } = default!;
    }
}
