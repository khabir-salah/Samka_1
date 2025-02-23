namespace Domain.Sheared.Entities;

public interface IAuditableEntity
{
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; }
    public Guid LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}