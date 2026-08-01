namespace NurserySystem.Domain.Entities;

public class Level : BaseEntity
{
    public string NameAr { get; set; } = string.Empty; // اسم المستوى بالعربي
    public string NameEn { get; set; } = string.Empty; // اسم المستوى بالإنجليزي
    public int Order { get; set; } // ترتيب المستوى (أصغر لأكبر)
    
    // Navigation Properties
    public ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();
}
