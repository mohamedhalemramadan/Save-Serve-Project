namespace NurserySystem.Domain.Entities;

public class ClassRoom : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public int LevelId { get; set; }
    public Level Level { get; set; } = null!;
    public int MaxCapacity { get; set; }
    public string? TeacherName { get; set; }
    public string? AssistantName { get; set; }
    public ICollection<Child> Children { get; set; } = new List<Child>();
}
