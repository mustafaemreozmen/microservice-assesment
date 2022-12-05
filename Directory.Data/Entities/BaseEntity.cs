namespace Directory.Data.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Creator { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string? Modifier { get; set; }
}
