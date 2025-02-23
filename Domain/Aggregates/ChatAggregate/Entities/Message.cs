

using Domain.Aggregates.ChatAggregate.Enum;
using Domain.Sheared.Entities;
using Domain.Sheared.ValueObjects;

namespace Domain.Aggregates.ChatAggregate.Entities
{
    public class Message : AuditableEntity<Guid>
    {
        public Guid ChatId { get; private set; }
        public Guid SenderId { get; private set; }
        public MessageContent MessageContent { get; private set; }
        public MessageType MessageType { get; private set; }

        public Message(Guid chatId, Guid senderId, MessageContent content, MessageType type)
        {
            ChatId = chatId;
            SenderId = senderId;
            MessageContent = content;
            MessageType = type;
        }

        
    }
}
