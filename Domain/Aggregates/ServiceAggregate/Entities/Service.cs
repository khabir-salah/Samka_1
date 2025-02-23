using Domain.Aggregates.ServiceAggregate.Entities;
using Domain.Sheared.Entities;

namespace Domain.Aggregates.ServiceBookingAggregate.Entities
{
    public class Service : AuditableEntity<Guid>
    {
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string Icon { get; private set; } = default!;
        public List<string> Locations { get; private set; }
        public virtual  ICollection<ServiceCategory> _services { get; set; } = new List<ServiceCategory>();
        public readonly List<ServiceProvider> _serviceProviders = new();
        public readonly List<Booking> _bookings = new();
        //public IReadOnlyCollection<ServiceCategory> ServiceCategories => _services.AsReadOnly();
        public IReadOnlyCollection<ServiceProvider> ServiceProviders => _serviceProviders.AsReadOnly();
        public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();

        public Service() { }

        public Service(string name, string description, string icon, List<string> locations)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Locations = locations;
        }

        public void AddServiceCategory(ServiceCategory serviceCategory)
        {
            _services.Add(serviceCategory);
        }

        public void UpdateService(string name, string description, string icon)
        {
            Name = name ?? Name;
            Description = description
                ?? Description;
            Icon = icon ?? Icon;
        }

        public void DeleteService(Guid ServiceId)
        {
            var service = _services.FirstOrDefault(s => s.Id == ServiceId);
            if (service != null)
            {
                _services.Remove(service);
            }
        }

        public bool IsCategoryExist(string name)
        {
            return _services.Any(s => s.Name == name);
        }


    }
}
