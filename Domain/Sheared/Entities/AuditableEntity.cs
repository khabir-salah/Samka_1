namespace Domain.Sheared.Entities;


public abstract class AuditableEntity<T> : BaseEntity, IAuditableEntity, ISoftDelete
{
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; private set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public Guid? DeletedBy { get; set; }

    protected AuditableEntity()
    {
        CreatedAt = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;
    }
}