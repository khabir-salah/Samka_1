using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Sheared.Entities;
public abstract class BaseEntity : BaseEntity<Guid>
{
    protected BaseEntity() => Id = Guid.NewGuid();


}

public abstract class BaseEntity<TId>
{
    public TId Id { get; protected set; } = default!;

}