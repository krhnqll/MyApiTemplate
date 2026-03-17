namespace Domain.Core;

public abstract class BaseAuditableEntity : BaseEntity
{
    // DateTime.Now yerine DateTimeOffset.Now kullanın
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.Now;

    public int? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; } = DateTimeOffset.Now;

    public int? LastModifiedBy { get; set; }

    public int Status { get; set; } = 1;
}
