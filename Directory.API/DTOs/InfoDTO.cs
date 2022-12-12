using Directory.Data.Enums;

namespace Directory.API.DTOs;
public class InformationDTO
{
    public InformationType InformationType { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
