namespace Popkultulista.Core.Common;

public class BaseEntity : AuditableModel
{
    public Guid Id { get; set; }

    public BaseEntity(int createdById, int modifiedById) : base(createdById, modifiedById)
    {
        this.Id = Guid.NewGuid();
    }
}