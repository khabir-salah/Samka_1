

using Domain.Aggregates.ChatAggregate.Enum;
using Domain.Sheared.Entities;

namespace Domain.Aggregates.ChatAggregate.Entities
{
    public class Attachment : BaseEntity
    {
        public Guid MessageId { get; private set; }
        public string FileUrl { get; private set; }
        public FileType FileType { get; private set; }

        public Attachment(Guid messageId, string fileUrl, FileType fileType)
        {
            MessageId = messageId;
            FileUrl = fileUrl;
            FileType = fileType;
        }

        
    }
}
