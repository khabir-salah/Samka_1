using Domain.Aggregates.ServiceBookingAggregate.Entities;
using Domain.Sheared.Entities;
using Domain.Sheared.ValueObjects;

namespace Domain.Aggregates.ServiceAggregate.Entities
{
    public class ServiceCategory : AuditableEntity<Guid>
    {
        public Guid ServiceId { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public DateTime AvgDuration { get; private set; }
        public ServiceQuestion ServiceQuestion { get; private set; }
        public List<ServiceProvider> ServiceProvider { get; private set; }
        public Service Service { get; private set; }


        public ServiceCategory() { }

        public ServiceCategory(Guid serviceId, string name, string description, DateTime avgDuration, ServiceQuestion serviceQuestion)
        {
            ServiceId = serviceId;
            Name = name;
            Description = description;
            AvgDuration = avgDuration;
            ServiceQuestion = serviceQuestion;
        }

        public void UpdateServiceCategory(string name, string description, decimal price, DateTime avgDuration, ServiceQuestion serviceQuestion)
        {
            Name = name ?? Name;
            Description = description ?? Description;
            AvgDuration = avgDuration;
            ServiceQuestion = serviceQuestion;
        }

        public void AddCategory(ServiceCategory category)
        {
            Service.AddServiceCategory(category);
        }

    }
}
