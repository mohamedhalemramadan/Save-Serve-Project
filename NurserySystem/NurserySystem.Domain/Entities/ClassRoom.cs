namespace NurserySystem.Domain.Entities;

public class ClassRoom : BaseEntity
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int LevelId { get; set; }
    public int MaxCapacity { get; set; } // الحد الأقصى للأطفال
    
    // Navigation Properties
    public Level? Level { get; set; }
    public ICollection<Child> Children { get; set; } = new List<Child>();
}
