namespace Domain.Core;

public abstract class BaseDictionaryEntity : BaseEntity
{
    public string Title { get; set; }
    public int Status { get; set; } = 1;

}
