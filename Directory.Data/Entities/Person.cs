namespace Directory.Data.Entities;

public class Person : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public ICollection<Information>? Informations { get; set; }
}
