

namespace Domain.Sheared.ValueObjects
{
    public class Availability
    {
        public Guid ServiceProviderId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }

        public Availability() { }

        public Availability(Guid serviceProviderId, DateTime startTime, DateTime endTime, DayOfWeek dayOfWeek)
        {
            ServiceProviderId = serviceProviderId;
            StartTime = startTime;
            EndTime = endTime;
            DayOfWeek = dayOfWeek;
        }
        public void UpdateAvailability(Guid serviceProviderId, DateTime startTime, DateTime endTime, DayOfWeek dayOfWeek)
        {
            ServiceProviderId = serviceProviderId;
            StartTime = startTime;
            EndTime = endTime;
            DayOfWeek = dayOfWeek;
        }
    }
}
