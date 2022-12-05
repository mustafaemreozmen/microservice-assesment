using Directory.Data.Enums;

namespace Directory.Data.Entities;

public class Information : BaseEntity
{
    public InformationType InformationType { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
