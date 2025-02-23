using Domain.Aggregates.ServiceBookingAggregate.Enum;
using Domain.Sheared.Entities;

namespace Domain.Aggregates.ServiceBookingAggregate.Entities
{
    public class Reviews : AuditableEntity<Guid>
    {
        public string? Comment { get; private set; }
        public Guid UserId { get; private set; }
        public double Rating { get; private set; }
        public Guid ServiceProviderId { get; private set; }
        public Guid ServiceID { get; private set; }
        public Rate Rate { get; private set; }

        public Reviews() { }

        public Reviews(string? comment, Guid UserId, double rating, Guid serviceProviderId, Guid serviceID, Rate rate)
        {
            Comment = comment;
            UserId = UserId;
            Rating = rating;
            ServiceProviderId = serviceProviderId;
            ServiceID = serviceID;
            Rate = rate;
        }
    }
}
