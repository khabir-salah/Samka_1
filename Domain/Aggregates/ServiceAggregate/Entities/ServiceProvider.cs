using Domain.Aggregates.ServiceBookingAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Sheared.Entities;
using Domain.Sheared.ValueObjects;

namespace Domain.Aggregates.ServiceAggregate.Entities
{
    public class ServiceProvider : AuditableEntity<Guid>
    {
        public ContactInformation ContactInformation { get; set; } = default!;
        public string ServiceProviderNo { get; private set; } = default!;
        public BankDetails BankDetails { get; private set; } = default!;
        public Guid UserID { get; private set; }
        public User User { get; private set; } = default!;
        public Guid CategoryId { get; private set; }
        public List<Service> Services { get; private set; } = default!;
        
        public Availability Availability { get; private set; }
        public List<Reviews> Reviews { get; private set; } = [];
        public virtual ServiceProviderProfile Profile { get; private set; } 
        public IReadOnlyCollection<Service> Service => Services.AsReadOnly();


        public ServiceProvider()
        {

        }

        public ServiceProvider(ContactInformation contactInformation, string serviceProviderNo, BankDetails bankDetails, string bio, Guid userID, User user, List<Reviews> reviews, List<Service> services)
        {
            ContactInformation = contactInformation;
            ServiceProviderNo = serviceProviderNo;
            BankDetails = bankDetails;
            UserID = userID;
            User = user;
            Services = services;
        }

        public void AddService(Guid serviceProviderId, List<Guid> servicesId, Guid categoryId)
        {
            var category = Service.FirstOrDefault(s => s.CategoryId == categoryId && s.ServiceProvider.Id == serviceProviderId);
            if (category == null)
            {
                CategoryId = categoryId;
                Id = serviceProviderId;
            }
        }
    }
}
