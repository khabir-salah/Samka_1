

using Domain.Sheared.Entities;

namespace Domain.Aggregates.ChatAggregate.Entities
{
    public class Chat : AuditableEntity<Guid>
    {
        public Guid? ProductId { get; private set; }
        public Guid? ServiceId { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid RecieverId { get; private set; }

        public Chat(Guid senderId, Guid recieverId, Guid? productId = null, Guid? serviceId = null)
        {
            SenderId = senderId;
            RecieverId = recieverId;
            ProductId = productId;
            ServiceId = serviceId;
        }

       
    }
}
