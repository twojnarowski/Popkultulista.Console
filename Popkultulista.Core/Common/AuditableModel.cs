namespace Popkultulista.Core.Common;

public class AuditableModel
{
    public int CreatedById { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public int? ModifiedById { get; set; }
    public DateTime? ModifiedDateTime { get; set; }

    public AuditableModel(int createdById, int modifiedById)
    {
        this.CreatedById = createdById;
        this.CreatedDateTime = DateTime.Now;
        this.ModifiedById = modifiedById;
        this.ModifiedDateTime = DateTime.Now;
    }
}