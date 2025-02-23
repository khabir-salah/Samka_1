using Domain.Aggregates.ServiceAggregate.Entities;
using Domain.Aggregates.ServiceBookingAggregate.Enum;
using Domain.Sheared.Entities;

namespace Domain.Aggregates.ServiceBookingAggregate.Entities
{
    public class Booking : AuditableEntity<Guid>
    {
        public List<Guid> ServiceCategoryId { get; private set; }
        public Guid UserId { get; private set; }         
        public List<Guid> ServiceProviderId { get; private set; }
        public DateTime BookingDate { get; private set; }
        public string Note { get; private set; } = default!;
        public BookingStatus BookingStatus { get; private set; }
        public List<ServiceQuestionResponse> ServiceQuestionResponses { get; private set; }

        public Booking() { }

        public Booking(List<Guid> serviceCategoryId, Guid UserId, List<Guid> serviceProviderId, DateTime bookingDate, string note, BookingStatus bookingStatus, List<ServiceQuestionResponse> serviceQuestionResponses)
        {
            ServiceCategoryId = serviceCategoryId;
            UserId = UserId;
            ServiceProviderId = serviceProviderId;
            BookingDate = bookingDate;
            Note = note;
            BookingStatus = bookingStatus;
            ServiceQuestionResponses = serviceQuestionResponses;
        }

        public void CancelBooking()
        {
            BookingStatus = BookingStatus.Canceled;
        }

        public void UpdateBookingStatus(BookingStatus bookingStatus)
        {
            BookingStatus = bookingStatus;
        }


    }
}
