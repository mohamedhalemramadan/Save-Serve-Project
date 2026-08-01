namespace NurserySystem.Domain.Entities;

public class Guardian : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? AlternatePhoneNumber { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string Relationship { get; set; } = string.Empty; // Father, Mother, Other
    public ICollection<Child> Children { get; set; } = new List<Child>();
}
