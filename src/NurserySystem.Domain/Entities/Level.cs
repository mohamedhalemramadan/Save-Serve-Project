namespace NurserySystem.Domain.Entities;

public class Level : BaseEntity
{
    public string Name { get; set; } = string.Empty; // KG1, KG2, Nursery 1, Nursery 2
    public string NameAr { get; set; } = string.Empty;
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();
}
