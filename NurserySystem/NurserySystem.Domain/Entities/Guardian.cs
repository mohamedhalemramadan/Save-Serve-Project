namespace NurserySystem.Domain.Entities;

public class Guardian : BaseEntity
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? AlternatePhone { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string Relationship { get; set; } = string.Empty; // أب، أم، ولي أمر
    
    // Navigation Properties
    public ICollection<Child> Children { get; set; } = new List<Child>();
}
